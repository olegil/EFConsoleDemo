using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo.models
{
    public class ModuleItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleItemId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }

        public virtual ICollection<ModuleAndItemRelationship> ModuleAndItemRelationships { get; set; }

        public ModuleItem()
        {
            ModuleAndItemRelationships = new HashSet<ModuleAndItemRelationship>();
        }
    }
}
