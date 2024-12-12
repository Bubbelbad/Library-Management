﻿using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.AddAuthor
{
    public class AddAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<AddAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        public IMapper _mapper = mapper;

        public async Task<OperationResult<Author>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.NewAuthor == null || string.IsNullOrEmpty(request.NewAuthor.FirstName))
            {
                return OperationResult<Author>.Failure("Invalid input");
            }

            try
            {
                Author authorToCreate = new()
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = request.NewAuthor.FirstName,
                    LastName = request.NewAuthor.LastName,
                };
                var createdAutor = await _authorRepository.AddAuthor(authorToCreate);
                var mappedAuthor = _mapper.Map<Author>(createdAutor);
                return OperationResult<Author>.Success(mappedAuthor);
            }
            catch
            {
                throw new Exception("AuthorId not added");
            }
        }
    }
}