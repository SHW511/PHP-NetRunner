using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using PNetRunner.Data;
using PNetRunner.Ext;

namespace PNetRunner.Pages
{
    public class IndexComponent : OwningComponentBase
    {
        [Inject]
        public PhpRunner PhpRunner { get; set; }

        public List<(string, Process)> Processes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Processes = PhpRunner.Processes.MapKnownPhpDirectories();
        }
    }
}
