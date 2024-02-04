using System.ComponentModel.DataAnnotations;
using ScientificActivities.StorageEnums;
using static System.String;

namespace ScientificActivities.Interfaces.Model.Files;

/// <summary>
///     Модель файла для загрузки
/// </summary>
public class AddFileModel
{
    /// <summary>
    ///     Содержимое файла в Base64
    /// </summary>
    public string FileBase64 { get; set; } = Empty;

    /// <summary>
    /// Имя файла
    /// </summary>
    [Required]
    public string Name { get; set; } = "unknown";
}