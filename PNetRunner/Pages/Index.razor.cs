using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using PNetRunner.Data;

namespace PNetRunner.Pages
{
    public class IndexComponent : OwningComponentBase
    {
        [Inject]
        public PhpRunner PhpRunner { get; set; }
    }
}
