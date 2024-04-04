using AutoMapper;
using ScientificActivities.Data.Models;
using ScientificActivities.Repository;
using ScientificActivities.Services.DTO;
using ScientificActivities.Services.Interfaces;

namespace ScientificActivities.Services.Services;

public class AuthorService : IAuthorService
{
    private IRepository<Author> _repository;
    
    Author Map(AuthorDTO authorsDTO)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>());
        var mapper = new Mapper(config);
        Author author = mapper.Map<AuthorDTO, Author>(authorsDTO);
        return author;
    }
    
    public IEnumerable<AuthorDTO> GetAllAuthors()
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>());
        var mapper = new Mapper(config);
        var authors = mapper.Map<List<AuthorDTO>>(_repository.GetAll());
        return authors;
    }

    public AuthorDTO GetAuthor(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>());
        var mapper = new Mapper(config);
        var authorsDTO = mapper.Map<AuthorDTO>(_repository.Get(id));
        return authorsDTO;
    }

    public void InsertAuthor(AuthorDTO authorsDTO)
    {
        Author author = Map(authorsDTO);
        _repository.Create(author);
        _repository.Save();
    }

    public void UpdateAuthor(AuthorDTO authorsDTO)
    {
        Author author = Map(authorsDTO);
        _repository.Update(author);
        _repository.Save();
    }

    public void DeleteAuthor(long id)
    {
        _repository.Delete(id);
        _repository.Save();
    }
}