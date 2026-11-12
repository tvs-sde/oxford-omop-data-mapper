using System.Diagnostics;
using NUnit.Framework;
using OmopTransformer;
using Assert = NUnit.Framework.Assert;

namespace OmopTransformerTests;

[TestFixture]
public class ProgramTests
{
    [TestCase("oxford-procedures")]
    [TestCase("unknown-transform")]
    public async Task UnknownTransformType_ExitsWithErrorWithoutStartingHost(string transformType)
    {
        var startInfo = new ProcessStartInfo("dotnet")
        {
            WorkingDirectory = AppContext.BaseDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        startInfo.ArgumentList.Add(typeof(TransformOptions).Assembly.Location);
        startInfo.ArgumentList.Add("transform");
        startInfo.ArgumentList.Add("--type");
        startInfo.ArgumentList.Add(transformType);

        using var process = Process.Start(startInfo)!;
        var standardOutput = process.StandardOutput.ReadToEndAsync();
        var standardError = process.StandardError.ReadToEndAsync();

        try
        {
            await process.WaitForExitAsync().WaitAsync(TimeSpan.FromSeconds(30));

            Assert.That(process.ExitCode, Is.EqualTo((int)ExitCodes.UnknownError));
            Assert.That(await standardError, Does.Contain($"Unknown transform type {transformType}."));
            Assert.That(await standardOutput, Does.Not.Contain("Application started."));
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync();
            }
        }
    }
}
