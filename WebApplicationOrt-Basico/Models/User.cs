using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOrt_Basico.Models
{

    public enum Genero
    {
        MASCULINO,
        FEMENINO
    }
    public class User
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int IdUsuario { get; set; }

            public string Apodo { get; set; }

            public string Email { get; set; }

            [Display(Name = "Fecha inscripción")]
            public DateTime FechaInscripto { get; set; }

            [EnumDataType(typeof(Genero))]
            public Genero Genero { get; set; }
        }
    }


