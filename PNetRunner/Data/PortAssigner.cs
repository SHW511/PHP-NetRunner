using System.Net.NetworkInformation;

namespace PNetRunner.Data
{
    /// <summary>
    /// Class responsible for generating a unique port number.
    /// </summary>
    public class PortAssigner
    {
        /// <summary>
        /// Generates a unique port number.
        /// </summary>
        /// <returns>A unique port number.</returns>
        public async Task<int> GeneratePortNumber()
        {
            int portNumber = 8000; // Starting port number

            while (await IsPortInUse(portNumber))
            {
                portNumber++;
            }

            return portNumber;
        }

        /// <summary>
        /// Generates a unique port number based on the last port number.
        /// </summary>
        /// <param name="lastPort">The last port number used.</param>
        /// <returns>A unique port number.</returns>
        public async Task<int> GeneratePortNumber(int lastPort = 0)
        {
            if(lastPort == 0)
            {
                return await GeneratePortNumber();
            }

            int portNumber = lastPort + 1;

            while (await IsPortInUse(portNumber))
            {
                portNumber++;
            }

            return portNumber;
        }

        /// <summary>
        /// Checks if the specified port is already in use.
        /// </summary>
        /// <param name="port">The port number to check.</param>
        /// <returns>True if the port is in use, false otherwise.</returns>
        private async Task<bool> IsPortInUse(int port)
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var activeTcpListeners = ipGlobalProperties.GetActiveTcpListeners();
            var activeUdpListeners = ipGlobalProperties.GetActiveUdpListeners();

            return await Task.FromResult(
                activeTcpListeners.Any(endpoint => endpoint.Port == port) ||
                activeUdpListeners.Any(endpoint => endpoint.Port == port));
        }
    }
}
