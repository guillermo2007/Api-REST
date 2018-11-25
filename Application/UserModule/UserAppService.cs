using Application.SecurityModule.Handlers;
using Application.UserModule.Interfaces;
using Application.UserModule.Resources;
using AutoMapper;
using Crosscrutting.Exceptions;
using Domain.SecurityModule.Enum;
using Domain.UserModule.Aggregates;
using DTO.UserModule;
using Repository.UserModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.UserModule
{
    public class UserAppService : IUserAppService
    {
        private IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AuditCallHandler(EnumPermision.Read,EnumObjectType.User)]
        public UserDto Get(int id)
        {
            try
            {
                var user = _userRepository.Get(id);
                if (user == null) throw new ServiceException(UserResource.ErrNotFound);
                return Mapper.Map<UserDto>(user);
            }
            catch (ServiceException ex)
            {
                throw ex;
            }           
        }

        public IEnumerable<UserDto> GetAll()
        {

            var users = _userRepository.GetAll().ToList();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public UserDto Add(UserDto value)
        {
            try
            {
                var user = new User(value.Name, value.Birthdate);
                var userDb = _userRepository.Add(user);
                return Mapper.Map<UserDto>(userDb);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDto Update(UserDto value)
        {
            try
            {
                var user = _userRepository.Get(value.Id);
                user.Name = value.Name;
                user.Birthdate = value.Birthdate;
                var userDb = _userRepository.Update(user);
                return Mapper.Map<UserDto>(userDb);
            }
            catch (ServiceException ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var user = _userRepository.Get(id);
                if(user == null) throw new ServiceException(UserResource.ErrNotFound);
                _userRepository.Delete(id);
            }
            catch (ServiceException ex)
            {
                throw ex;
            } 
        }
    }
}
