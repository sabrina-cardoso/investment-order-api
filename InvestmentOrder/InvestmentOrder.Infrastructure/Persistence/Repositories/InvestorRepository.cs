using InvestmentOrder.Domain.Entities;
using InvestmentOrder.Domain.Ports.Out;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InvestmentOrder.Infrastructure.Persistence.Repositories;

public class InvestorRepository : IInvestorRepository
{
    private readonly string _connectionString;

    public InvestorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlServer");
    }
    public async Task<bool> AddAsync(Investor investor)
    {
        try
        {
            const string query = @"
            INSERT INTO Investors (Name, Document, ProfileId)
            VALUES (@Name, @Document, @ProfileId);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", investor.Name);
                    command.Parameters.AddWithValue("@Document", investor.Document);
                    command.Parameters.AddWithValue("@ProfileId", (int)investor.Profile);

                    var result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        investor.Id = id;
                        return true;
                    }

                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting the investor into the database.", ex);
        }
       
    }

    public async Task<IEnumerable<Investor>> GetAllAsync()
    {
        try
        {
            const string query = @"
            SELECT *
            FROM Investors;";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var investors = new List<Investor>();
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("Id"));
                        var name = reader.GetString(reader.GetOrdinal("Name"));
                        var document = reader.GetString(reader.GetOrdinal("Document"));
                        var profile = (InvestorProfile)reader.GetInt32(reader.GetOrdinal("ProfileId"));
                        var createdAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
                        investors.Add(Investor.Load(id, name, document, profile, createdAt));
                    }
                    return investors;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while get the investors into the database.", ex);
        }
        
    }

    public async Task<Investor?> GetByIdAsync(int id)
    {
        try
        {
            const string query = @"
            SELECT *
            FROM Investors
            WHERE Id = @Id;";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var name = reader.GetString(reader.GetOrdinal("Name"));
                            var document = reader.GetString(reader.GetOrdinal("Document"));
                            var profile = (InvestorProfile)reader.GetInt32(reader.GetOrdinal("ProfileId"));
                            var createdAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));

                            return Investor.Load(id, name, document, profile, createdAt);
                        }

                        return null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while get the investor into the database.", ex);
        }
        
    }
}

