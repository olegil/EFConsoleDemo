using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleDemo.models
{
    public enum ModuleCategoryName { Home, Student, Staff, Alumni }

    public class ModuleCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleCategoryId { get; set; }
        [Required]
        public ModuleCategoryName Name { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

        public ModuleCategory()
        {
            Modules = new HashSet<Module>();
        }
    }
}
