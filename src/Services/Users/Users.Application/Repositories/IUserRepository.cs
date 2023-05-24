﻿using Users.Domain.SeedWork;

namespace Users.Application.Repositories;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    void Update(User user);
    Task<User> GetAsync(UserId userId);
}
