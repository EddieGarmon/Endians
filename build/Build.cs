using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{

    [Parameter("Configuration to build - Default is 'Release'")]
    readonly Configuration Configuration = Configuration.Debug;

    [Parameter]
    [Secret]
    readonly string NugetApiKey;

    [Parameter]
    readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json";

    [Solution]
    readonly Solution Solution;

    AbsolutePath ArtifactsDirectory => RootDirectory / "Artifacts";

    Target Clean =>
        _ => _.Before(Restore)
              .Executes(() => {
                            foreach (Project project in Solution.AllProjects.Where(project => project.Name != "_build")) {
                                project.Directory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                            }
                            EnsureCleanDirectory(ArtifactsDirectory);
                        });

    Target Compile =>
        _ => _.DependsOn(Restore)
              .Executes(() => {
                            DotNetBuild(s => s.SetProjectFile(Solution)
                                              .SetConfiguration(Configuration)
                                              .EnableNoLogo()
                                              .EnableNoRestore()
                                              .EnableDeterministic()
                                              .EnableContinuousIntegrationBuild());
                        });

    Target Pack =>
        _ => _.DependsOn(Compile)
              .After(Test)
              .Produces(ArtifactsDirectory)
              .Executes(() => {
                            DotNetPack(s => s.SetProject(Solution)
                                             .SetConfiguration(Configuration)
                                             .SetOutputDirectory(ArtifactsDirectory)
                                             .EnableNoLogo()
                                             .EnableNoRestore()
                                             .EnableNoBuild()
                                             .EnableContinuousIntegrationBuild());
                        });

    Target Publish =>
        _ => _.DependsOn(Clean)
              .DependsOn(Test)
              .DependsOn(Pack)
              .Executes(() => {
                            GlobFiles(ArtifactsDirectory, "*.nupkg")
                                .ForEach(packageName => DotNetNuGetPush(s => s.SetTargetPath(packageName)
                                                                              .SetSource(NugetApiUrl)
                                                                              .SetApiKey(NugetApiKey)
                                                                              .EnableSkipDuplicate()));
                        });

    Target Restore => _ => _.Executes(() => { DotNetRestore(s => s.SetProjectFile(Solution)); });

    Target Test =>
        _ => _.DependsOn(Compile)
              .Executes(() => {
                            DotNetTest(_ => _.SetProjectFile(Solution).EnableNoLogo().EnableNoBuild().SetConfiguration(Configuration));
                        });

    public static int Main() => Execute<Build>(x => x.Compile);

}