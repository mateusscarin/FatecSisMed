using System.ComponentModel.DataAnnotations;

namespace FatecSisMed.MedicoAPI.DTO.Entities;

public class MarcaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório!")]
    public string? Nome { get; set; }
    public string? Observacao { get; set; }
}
