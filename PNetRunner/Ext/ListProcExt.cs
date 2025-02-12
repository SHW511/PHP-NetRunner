using System.Diagnostics;

namespace PNetRunner.Ext
{
    /// <summary>
    /// Extension methods for working with lists of processes.
    /// </summary>
    public static class ListProcExt
    {
        /// <summary>
        /// Maps known PHP directories from a list of processes.
        /// </summary>
        /// <param name="processes">The list of processes.</param>
        /// <returns>A list of tuples containing the directory name and the corresponding process.</returns>
        public static List<(string, Process)> MapKnownPhpDirectories(this List<Process> processes)
        {
            var procdList = processes.MapAsKeyValuePair();
            List<(string, Process)> res = new List<(string, Process)>();

            foreach (var process in procdList)
            {
                switch (process.Item1.Split("\\").Last())
                {
                    case "PhpMyAdmin":
                        res.Add(("PhpMyAdmin", process.Item2));
                        continue;

                    default:
                        res.Add((process.Item1.Split("\\").Last(), process.Item2));
                        break;
                }
            }

            return res;
        }

        /// <summary>
        /// Maps a list of processes as key-value pairs.
        /// </summary>
        /// <param name="processes">The list of processes.</param>
        /// <returns>A list of tuples containing the working directory and the corresponding process.</returns>
        private static List<(string, Process)> MapAsKeyValuePair(this List<Process> processes)
        {
            var res = new List<(string, Process)>();
            foreach (var process in processes)
            {
                res.Add((process.StartInfo.WorkingDirectory, process));
            }

            return res;
        }

    }
}
