namespace PSS.Migrations
{
    using PSS.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SGCO.Context.Context>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SGCO.Context.Context context)
        {
            SeedCountries(context);
            SeedStates(context);
            SeedCities(context);
            SeedUserTypes(context);           
            SeedUnits(context);
            SeedCategories(context);
            SeedManufacturers(context);
            SeedProviders(context);
            SeedProducts(context);
            SeedUsers(context);
        }

        private void SeedCountries(SGCO.Context.Context context)
        {
            context.Countries.AddOrUpdate(c => c.Id,
                new Country { Id = 01, Name = "Brasil" });
        }

        private void SeedStates(SGCO.Context.Context context)
        {
            context.States.AddOrUpdate(s => s.Id,
                new State { Id = 01, UF = "AC", CountryId = 01, Name = "Acre" },
                new State { Id = 02, UF = "AL", CountryId = 01, Name = "Alagoas" },
                new State { Id = 03, UF = "AP", CountryId = 01, Name = "Amapá" },
                new State { Id = 04, UF = "AM", CountryId = 01, Name = "Amazonas" },
                new State { Id = 05, UF = "BA", CountryId = 01, Name = "Bahia" },
                new State { Id = 06, UF = "CE", CountryId = 01, Name = "Ceará" },
                new State { Id = 07, UF = "DF", CountryId = 01, Name = "Distrito Federal" },
                new State { Id = 08, UF = "ES", CountryId = 01, Name = "Espírito Santo" },
                new State { Id = 09, UF = "GO", CountryId = 01, Name = "Goiás" },
                new State { Id = 10, UF = "MA", CountryId = 01, Name = "Maranhão" },
                new State { Id = 11, UF = "MT", CountryId = 01, Name = "Mato Grosso" },
                new State { Id = 12, UF = "MS", CountryId = 01, Name = "Mato Grosso do Sul" },
                new State { Id = 13, UF = "MG", CountryId = 01, Name = "Minas Gerais" },
                new State { Id = 14, UF = "PA", CountryId = 01, Name = "Pará" },
                new State { Id = 15, UF = "PB", CountryId = 01, Name = "Paraíba" },
                new State { Id = 16, UF = "PR", CountryId = 01, Name = "Paraná" },
                new State { Id = 17, UF = "PE", CountryId = 01, Name = "Pernambuco" },
                new State { Id = 18, UF = "PI", CountryId = 01, Name = "Piauí" },
                new State { Id = 19, UF = "RJ", CountryId = 01, Name = "Rio de Janeiro" },
                new State { Id = 20, UF = "RN", CountryId = 01, Name = "Rio Grande do Norte" },
                new State { Id = 21, UF = "RS", CountryId = 01, Name = "Rio Grande do Sul" },
                new State { Id = 22, UF = "RO", CountryId = 01, Name = "Rondônia" },
                new State { Id = 23, UF = "RR", CountryId = 01, Name = "Roraima" },
                new State { Id = 24, UF = "SC", CountryId = 01, Name = "Santa Catarina" },
                new State { Id = 25, UF = "SP", CountryId = 01, Name = "São Paulo" },
                new State { Id = 26, UF = "SE", CountryId = 01, Name = "Sergipe" },
                new State { Id = 27, UF = "TO", CountryId = 01, Name = "Tocantins" });
        }

        private void SeedCities(SGCO.Context.Context context)
        {
            context.Cities.AddOrUpdate(c => c.Id,
                new City { Id = 01, StateId = 01, Name = "Rio Branco" },
                new City { Id = 02, StateId = 02, Name = "Maceió" },
                new City { Id = 03, StateId = 03, Name = "Macapá" },
                new City { Id = 04, StateId = 04, Name = "Manaus" },
                new City { Id = 05, StateId = 05, Name = "Salvador" },
                new City { Id = 06, StateId = 06, Name = "Fortaleza" },
                new City { Id = 07, StateId = 07, Name = "Brasília" },
                new City { Id = 08, StateId = 08, Name = "Vitória" },
                new City { Id = 09, StateId = 09, Name = "Goiânia" },
                new City { Id = 10, StateId = 10, Name = "São Luís" },
                new City { Id = 11, StateId = 11, Name = "Cuiabá" },
                new City { Id = 12, StateId = 12, Name = "Campo Grande" },
                new City { Id = 13, StateId = 13, Name = "Belo Horizonte" },
                new City { Id = 14, StateId = 14, Name = "Belém" },
                new City { Id = 15, StateId = 15, Name = "João Pessoa" },
                new City { Id = 16, StateId = 16, Name = "Curitiba" },
                new City { Id = 17, StateId = 17, Name = "Recife" },
                new City { Id = 18, StateId = 18, Name = "Teresina" },
                new City { Id = 19, StateId = 19, Name = "Rio de Janeiro" },
                new City { Id = 20, StateId = 20, Name = "Natal" },
                new City { Id = 21, StateId = 21, Name = "Porto Alegre" },
                new City { Id = 22, StateId = 22, Name = "Porto Velho" },
                new City { Id = 23, StateId = 23, Name = "Boa Vista" },
                new City { Id = 24, StateId = 24, Name = "Florianópolis" },
                new City { Id = 25, StateId = 25, Name = "São Paulo" },
                new City { Id = 26, StateId = 26, Name = "Aracaju" },
                new City { Id = 27, StateId = 27, Name = "Palmas" },
                new City { Id = 28, StateId = 16, Name = "Maringá" },
                new City { Id = 29, StateId = 25, Name = "São Bernardo do Campo" },
                new City { Id = 30, StateId = 25, Name = "Presidente Prudente" });
        }

        private void SeedUserTypes(SGCO.Context.Context context)
        {
            context.UserTypes.AddOrUpdate(u => u.Id,
                new UserType { Id = 1, Description = "Administrador" },
                new UserType { Id = 2, Description = "Cliente" },
                new UserType { Id = 3, Description = "Visitante" });
        }

        private void SeedUnits(SGCO.Context.Context context)
        {
            context.Units.AddOrUpdate(u => u.Id,
                new Unit { Id = 1, Description = "Peça" },
                new Unit { Id = 2, Description = "Caixa" },
                new Unit { Id = 3, Description = "Pacote" });
        }

        private void SeedCategories(SGCO.Context.Context context)
        {
            context.Categories.AddOrUpdate(c => c.Id,
                new Category { Id = 1, IsPerishable = false, Name = "Guitarra" },
                new Category { Id = 2, IsPerishable = false, Name = "Violão" },
                new Category { Id = 3, IsPerishable = false, Name = "Baixo" },
                new Category { Id = 4, IsPerishable = false, Name = "Bateria" },
                new Category { Id = 5, IsPerishable = false, Name = "Teclado" },
                new Category { Id = 6, IsPerishable = false, Name = "Piano" },
                new Category { Id = 7, IsPerishable = false, Name = "Saxofone" });
        }

        private void SeedManufacturers(SGCO.Context.Context context)
        {
            context.Manufacturers.AddOrUpdate(m => m.Id,
                new Manufacturer
                {
                    Id = 1,
                    ShortName = "Fender",
                    FullName = "Fender Musical Instruments Corporation",
                    CNPJ = "12.443.211/0001-88",
                    Phone = "(11) 3892-0433",
                    Email = "contato@fender.com.br",
                    Address = "Rua Arandu, 205 - Brooklin Novo - São Paulo-SP",
                    Complement = "Ed. Berrini Business Center",
                    Number = 205,
                    PostalCode = "04562-030",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 2,
                    ShortName = "Gibson",
                    FullName = "Gibson Brands, Inc.",
                    CNPJ = "88.564.586/0001-68",
                    Phone = "(11) 2191-2850",
                    Email = "contato@gibson.com.br",
                    Address = "Av. Jabaquara, 2049 - Mirandópolis - São Paulo-SP",
                    Complement = null,
                    Number = 2049,
                    PostalCode = "04045-003",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 3,
                    ShortName = "Tagima",
                    FullName = "Marutec Ind. Com. Imp. Exp. Ltda.",
                    CNPJ = "52.252.278/0001-50",
                    Phone = "(11) 4343-2900",
                    Email = "contato@tagima.com.br",
                    Address = "Estrada Sadae Takagi, 1950 - Cooperativa - São Bernardo do Campo-SP",
                    Complement = "Cooperativa",
                    Number = 1950,
                    PostalCode = "09852-070",
                    CityId = 29
                },
                new Manufacturer
                {
                    Id = 4,
                    ShortName = "Takamine",
                    FullName = "Takamine Gakki Seisakusho, Ltda.",
                    CNPJ = "27.196.854/0001-41",
                    Phone = "(18) 3941-2022",
                    Email = "contato@takamine.com.br",
                    Address = "Rodovia Raposo Tavares, 242 - KM 555 - Presidente Prudente-SP",
                    Complement = "KM 555",
                    Number = 242,
                    PostalCode = "19570-000",
                    CityId = 30
                });
        }

        private void SeedProviders(SGCO.Context.Context context)
        {
            context.Providers.AddOrUpdate(p => p.Id,
                new Provider
                {
                    Id = 1,
                    ShortName = "Marutec",
                    FullName = "Marutec Ind. Com. Imp. Exp. Ltda.",
                    CNPJ = "52.252.278/0001-50",
                    Phone = "(11) 4343-2900",
                    Email = "contato@marutec.com.br",
                    Address = "Estrada Sadae Takagi, 1950 - Cooperativa - São Bernardo do Campo-SP",
                    Complement = "Cooperativa",
                    Number = 1950,
                    PostalCode = "09852-070",
                    CityId = 29
                },
                new Provider
                {
                    Id = 2,
                    ShortName = "Musitech",
                    FullName = "Musitech Instrumentos Musicais, Ltda.",
                    CNPJ = "66.652.569/0001-40",
                    Phone = "(44) 3034-7057",
                    Email = "contato@musitechinstrumentos.com.br",
                    Address = "Av. Herval, 695 - Centro - Maringá-PR",
                    Complement = null,
                    Number = 695,
                    PostalCode = "87013-110",
                    CityId = 28
                });
        }

        private void SeedProducts(SGCO.Context.Context context)
        {
            context.Products.AddOrUpdate(p => p.Id,
                new Product
                {
                    Id = 1,
                    Description = "Fender Stratocaster Stardard - Artic White",
                    PurchasePrice = 1788.00,
                    SalePrice = 5364.00,
                    Stock = 3,
                    Weight = 3.6,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 2,
                    UnitId = 1
                },
                new Product
                {
                    Id = 2,
                    Description = "Gibson Les Paul Traditional - Honery Burst",
                    PurchasePrice = 2967.00,
                    SalePrice = 8901.00,
                    Stock = 5,
                    Weight = 4.2,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    ProviderId = 2,
                    UnitId = 1
                },
                new Product
                {
                    Id = 3,
                    Description = "Violão Tagima Dallas T - Sunburst",
                    PurchasePrice = 209.33,
                    SalePrice = 628.00,
                    Stock = 10,
                    Weight = 1.2,
                    Expiration = null,
                    CategoryId = 2,
                    ManufacturerId = 3,
                    ProviderId = 1,
                    UnitId = 1
                },
                new Product
                {
                    Id = 4,
                    Description = "Violão Takamine EF340S TT & TLD",
                    PurchasePrice = 3207.00,
                    SalePrice = 9621.00,
                    Stock = 1,
                    Weight = 1.5,
                    Expiration = null,
                    CategoryId = 2,
                    ManufacturerId = 4,
                    ProviderId = 1,
                    UnitId = 1
                });
        }

        private void SeedUsers(SGCO.Context.Context context)
        {
            context.Users.AddOrUpdate(u => u.Id,
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    LastName = "User",
                    CPF = "000.000.000-00",
                    Birth = System.DateTime.Today,
                    Gender = Gender.Undefined,
                    Phone = "(00) 0000-0000",
                    Email = "admin@admin.com",
                    Password = "admin",
                    UserTypeId = 1,
                    Address = "None",
                    Number = 0,
                    PostalCode = "00000-000",
                    CityId = 28
                },
                new User
                {
                    Id = 2,
                    Name = "Client",
                    LastName = "User",
                    CPF = "000.000.000-00",
                    Birth = System.DateTime.Today,
                    Gender = Gender.Undefined,
                    Phone = "(00) 0000-0000",
                    Email = "client@client.com",
                    Password = "client",
                    UserTypeId = 2,
                    Address = "None",
                    Number = 0,
                    PostalCode = "00000-000",
                    CityId = 28
                },
                new User
                {
                    Id = 3,
                    Name = "Visitor",
                    LastName = "User",
                    CPF = "000.000.000-00",
                    Birth = System.DateTime.Today,
                    Gender = Gender.Undefined,
                    Phone = "(00) 0000-0000",
                    Email = "visitor@visitor.com",
                    Password = "visitor",
                    UserTypeId = 3,
                    Address = "None",
                    Number = 0,
                    PostalCode = "00000-000",
                    CityId = 28
                });
        }
    }
}
