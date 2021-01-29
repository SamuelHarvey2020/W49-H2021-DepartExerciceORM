using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestORMCodeFirst.Entities
{
    [Table("COURS")]
    public class Cours
    {
        //Propriétés

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(10)")]
        public string CodeCours { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NomCours { get; set; }

        public virtual ICollection<InscriptionCours> Cours { get; set; }
    }
}