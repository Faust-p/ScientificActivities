﻿using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Models.Publication;

public class ArticlesAuthors : BaseModel
{
    public Article Article { get; set; } = null!;

    public Author Author { get; set; } = null!;
    
    public ArticlesAuthors(Article article, Author author)
    {
        Article = article;
        Author = author;
    }
}