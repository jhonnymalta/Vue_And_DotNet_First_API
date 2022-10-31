using api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace api.Repositories;

public class UserRepository
{

    private readonly MySqlConnection _connection;
    public UserRepository(MySqlConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<UserModel> GetAll()
    {
        using (_connection)
        {
            return _connection.GetAll<UserModel>();
        }



    }
    public UserModel Post(UserModel model)
    {
        using (_connection)
        {
            _connection.Insert<UserModel>(model);
            return model;
        }


    }
    public UserModel GetById(int id)
    {
        using (_connection)
        {
            return _connection.Get<UserModel>(id);
        }
    }

    public bool Put(UserModel model, int id)
    {
        using (_connection)
        {
            var user = _connection.Get<UserModel>(id);
            if (user == null)
            {
                return false;
            }
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            _connection.Update(user);
            return true;
        }
    }
    public bool Delete(int id)
    {
        using (_connection)
        {
            var user = _connection.Get<UserModel>(id);
            if(user == null)
            {
                return false;
            }
            _connection.Delete(user);
            return true;
                
        }
    }

}