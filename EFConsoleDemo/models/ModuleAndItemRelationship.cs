using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo.models
{
    public class ModuleAndItemRelationship
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("ModuleItem")]
        public int ModuleItemId { get; set; }

        public int ItemIndex { get; set; }

        public virtual Module Module { get; set; }

        public virtual ModuleItem ModuleItem { get; set; }
    }
}
