using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo.models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ColumnIndex { get; set; }
        [Required]
        public int RowIndex { get; set; }

        public int ModuleCategoryId { get; set; }
        public virtual ModuleCategory ModuleCategory { get; set; }

        public virtual ICollection<ModuleAndItemRelationship> ModuleAndItemRelationships { get; set; }

        public Module()
        {
            ModuleAndItemRelationships = new HashSet<ModuleAndItemRelationship>();
        }
    }
}
