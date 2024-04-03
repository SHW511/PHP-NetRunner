using System.Diagnostics;
using Microsoft.Extensions.Options;
using PNetRunner.Options;

namespace PNetRunner.Data
{
    public class PhpRunner
    {
        public List<Process> Processes { get; set; } = new List<Process>();
        
        private PortAssigner _portAssigner;
        private PhpSettings _phpSettings;
        private ILogger<PhpSettings> _logger;
        private IHostApplicationLifetime _lifetimeService;

        public PhpRunner(PortAssigner portAssigner, IOptions<PhpSettings> options, ILogger<PhpSettings> logger, IHostApplicationLifetime hostApplicationLifetime)
        {
            _portAssigner = portAssigner;
            _phpSettings = options.Value;
            _logger = logger;
            _lifetimeService = hostApplicationLifetime;
            _lifetimeService.ApplicationStopping.Register(ShutdownListeners);
        }

        private void ShutdownListeners()
        {
            foreach (var process in Processes)
            {
                process.Kill();
                _logger.LogInformation("Killed PHP server on port {port}", process.StartInfo.Arguments.Split(":").Last());
            }
        }

        [Obsolete]
        public void MapPhpContainers()
        {
            var contentDirectories = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "PHP_content")).ToList();

            foreach (var contentDirectory in contentDirectories)
            {

                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = $"{_phpSettings.ServerPath}",
                        Arguments = $"-S localhost:8000",
                        WorkingDirectory = contentDirectory,
                        RedirectStandardOutput = true,
                        //RedirectStandardError = true,
                    }
                };

                process.OutputDataReceived += (sender, args) => _logger.LogInformation(args.Data);
                //process.ErrorDataReceived += (sender, args) => _logger.LogInformation(args.Data);

                Processes.Add(process);
                process.Start();
            }
        }

        public async Task<bool> MapPhpContainersAsync()
        {
            var contentDirectories = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "PHP_content")).ToList();
            List<int> preAssignedPort = new List<int>();

            foreach (var contentDirectory in contentDirectories)
            {
                int port = await _portAssigner.GeneratePortNumber(preAssignedPort.LastOrDefault());

                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = $"{_phpSettings.ServerPath}",
                        Arguments = $"-S localhost:{port}",
                        WorkingDirectory = contentDirectory,
                        RedirectStandardOutput = true,
                        //RedirectStandardError = true,
                    }
                };

                process.OutputDataReceived += (sender, args) => _logger.LogInformation(args.Data);

                _logger.LogInformation($"Starting PHP server on port {port} for directory {contentDirectory}");
                preAssignedPort.Add(port);

                Processes.Add(process);
                process.Start();

            }

            return await Task.FromResult(true);
        }

        public async Task StopContainers()
        {
            ShutdownListeners();
            Processes.Clear();

            await Task.CompletedTask;
        }
    }
}
