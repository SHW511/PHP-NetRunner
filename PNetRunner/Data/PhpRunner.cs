using System.Diagnostics;
using Microsoft.Extensions.Options;
using PNetRunner.Options;

namespace PNetRunner.Data
{
    public class PhpRunner
    {
        private PhpSettings _phpSettings;
        private ILogger<PhpSettings> _logger;

        private List<Process> _processes = new List<Process>();

        IHostApplicationLifetime _lifetimeService;

        public PhpRunner(IOptions<PhpSettings> options, ILogger<PhpSettings> logger, IHostApplicationLifetime hostApplicationLifetime)
        {
            _phpSettings = options.Value;
            _logger = logger;
            _lifetimeService = hostApplicationLifetime;

            _lifetimeService.ApplicationStopping.Register(() =>
            {
                foreach (var process in _processes)
                {
                    process.Kill();
                }
            });
        }

        public void MapPhpContainers()
        {
            var contentDirectories = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "PHP_content")).ToList();

            foreach (var contentDirectory in contentDirectories)
            {
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        //Arguments = $"-S localhost:8000 -f {Path.Combine(contentDirectory)}",

                        Arguments = $"-S localhost:8000 -f {Path.Combine(contentDirectory, "index.php")}",
                        FileName = $"{_phpSettings.ServerPath}",
                        RedirectStandardOutput = true,
                        //RedirectStandardInput = true,
                    }
                };

                process.OutputDataReceived += (sender, args) => _logger.LogInformation(args.Data);
                _processes.Add(process);
                process.Start();
            }
        }
    }
}
