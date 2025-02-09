using Dapper;
using New_folder.Controllers;
using Npgsql;

namespace New_folder.Repositories;

public class StudentRepository
{
    private readonly IConfiguration _configuration;

    public StudentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<Student?> GetByIdAsync(int id)
    {
        const string selectQuery = $"""
                                    select * from members where id=@id 
                                    """;
        var connectionString = _configuration.GetConnectionString("Default");
        await using var connection = new NpgsqlConnection(connectionString);
        var member = await connection.QueryFirstOrDefaultAsync<Student>(selectQuery,
            new
            {
                id = id
            });
        return member;
    }

    public async Task<List<Student>> GetAllAsync(string firstname)
    {
        const string selectQuery = $"""
                                    select * from members where first_name=@firstname
                                    """;
        var connectionString = _configuration.GetConnectionString("Default");
        await using var connection = new NpgsqlConnection(connectionString);
        var members = (await connection.QueryAsync<Student>(selectQuery,
            new
            {
                firstname = firstname
            })).ToList();
        return members;

    }
}


