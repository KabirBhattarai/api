using Dapper;
using New_folder.Controllers;
using Npgsql;

namespace New_folder.Services;

public class StudentService
{
    private readonly IConfiguration _configuration;
    
    public async Task CreateAsync(StudentDto studentDto)
    {
        const string insertQuery = $"""
                                    insert into members (first_name, email, phone, address)
                                    values(@firstName, @email, @phone, @address)
                                    """;
        var connectionString = _configuration.GetConnectionString("Default");
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.ExecuteAsync(insertQuery, new
        {
            firstName = studentDto.FirstName,
            email = studentDto.Email,
            phone = studentDto.Phone,
            address = studentDto.Address
        });
    }

    public async Task UpdateAsync(int id, StudentDto studentDto)
    {
        const string updateQuery = $"""
                                    update members 
                                    set first_name = @firstName, email = @email, phone = @phone, address = @address
                                    where id = @id
                                    """;
        var connectionString = _configuration.GetConnectionString("Default");
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.ExecuteAsync(updateQuery, new
        {
            id = id,
            firstName = studentDto.FirstName,
            email = studentDto.Email,
            phone = studentDto.Phone,
            address = studentDto.Address
        });
    }

    public async Task DeleteAsync(int id)
    {
        const string deleteQuery = $"""
                                    delete from members where id=@id
                                    """;
        var connectionString = _configuration.GetConnectionString("Default");
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.ExecuteAsync(deleteQuery, new
        {
            id = id
        });
    }
}