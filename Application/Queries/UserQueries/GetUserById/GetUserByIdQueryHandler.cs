﻿using Application.Dtos.UserDtos;
using Application.Interfaces.RepositoryInterfaces;
using AutoMapper;
using Domain.Model;
using MediatR;


namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, OperationResult<GetUserDto>>
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                return OperationResult<GetUserDto>.Failure("Invalid input");
            }

            try
            {
                var user = await _userRepository.GetUserById(request.Id);
                var mappedUser = _mapper.Map<GetUserDto>(user);
                return OperationResult<GetUserDto>.Success(mappedUser);
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
