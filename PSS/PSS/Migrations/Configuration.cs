using PSS.Models;
using SGCO.Context;
using System.Data.Entity.Migrations;

namespace PSS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        private Context db;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context context)
        {
            db = context;

            SeedCountries();
            SeedStates();
            SeedCities();
            SeedUnits();
            SeedCategories();
            SeedManufacturers();
            SeedProviders();
            SeedProducts();
            SeedUsers();
        }

        private void SeedCountries()
        {
            db.Countries.AddOrUpdate(c => c.Id,
                new Country { Id = 01, Name = "Brasil" });
        }

        private void SeedStates()
        {
            db.States.AddOrUpdate(s => s.Id,
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

        private void SeedCities()
        {
            db.Cities.AddOrUpdate(c => c.Id,
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
                new City { Id = 30, StateId = 25, Name = "Presidente Prudente" },
                new City { Id = 31, StateId = 16, Name = "Londrina" });
        }

        private void SeedUnits()
        {
            db.Units.AddOrUpdate(u => u.Id,
                new Unit { Id = 1, Description = "Peça" },
                new Unit { Id = 2, Description = "Caixa" },
                new Unit { Id = 3, Description = "Pacote" },
                new Unit { Id = 4, Description = "Unidade" },
                new Unit { Id = 5, Description = "Tonel" },
                new Unit { Id = 6, Description = "Granel" });
        }

        private void SeedCategories()
        {
            db.Categories.AddOrUpdate(c => c.Id,
                new Category { Id = 1, IsPerishable = false, Name = "Guitarra" },
                new Category { Id = 2, IsPerishable = false, Name = "Violão" },
                new Category { Id = 3, IsPerishable = false, Name = "Baixo" },
                new Category { Id = 4, IsPerishable = false, Name = "Bateria" },
                new Category { Id = 5, IsPerishable = false, Name = "Teclado" },
                new Category { Id = 6, IsPerishable = false, Name = "Piano" },
                new Category { Id = 7, IsPerishable = false, Name = "Saxofone" });
        }

        private void SeedManufacturers()
        {
            db.Manufacturers.AddOrUpdate(m => m.Id,
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
                },
                new Manufacturer
                {
                    Id = 5,
                    ShortName = "Dean Guitars",
                    FullName = "Dean Guitars, Ltda.",
                    CNPJ = "09.243.015/0001-55",
                    Phone = "(41) 3322-4077",
                    Email = "contato@dean-guitars.com.br",
                    Address = "Rua XV de Novembro, 74 - Centro - Curitiba-PR",
                    Complement = null,
                    Number = 74,
                    PostalCode = "80020-330",
                    CityId = 16
                },
                new Manufacturer
                {
                    Id = 6,
                    ShortName = "PRS Guitars",
                    FullName = "Paul Reed Smith Guitars, Ltda.",
                    CNPJ = "34.616.008/0001-07",
                    Phone = "(21) 2490-8868",
                    Email = "contato@prs.com.br",
                    Address = "Avenida das Américas, 3501 - Barra da Tijuca - Rio de Janeiro-RJ",
                    Complement = null,
                    Number = 3501,
                    PostalCode = "22631-003",
                    CityId = 19
                },
                new Manufacturer
                {
                    Id = 7,
                    ShortName = "MusicMan",
                    FullName = "MusicMan, Ltda.",
                    CNPJ = "16.243.867/0001-08",
                    Phone = "(11) 5535-2003",
                    Email = "contato@musicman.com.br",
                    Address = "Rua Capitão Luís Ramos, 106 - Vila Guilherme - São Paulo-SP",
                    Complement = null,
                    Number = 106,
                    PostalCode = "02066-010",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 8,
                    ShortName = "ESP",
                    FullName = "ESP Company, Ltda.",
                    CNPJ = "89.867.517/0001-96",
                    Phone = "(41) 3346-4846",
                    Email = "contato@esp.com.br",
                    Address = "Rua José Zaleski, 240 - Capão Raso - Curitiba-PR",
                    Complement = null,
                    Number = 240,
                    PostalCode = "81130-060",
                    CityId = 16
                },
                new Manufacturer
                {
                    Id = 9,
                    ShortName = "Ibanez",
                    FullName = "Ibanez Guitars, Ltda.",
                    CNPJ = "30.385.069/0001-41",
                    Phone = "(85) 3035-7428",
                    Email = "contato@ibanez.com.br",
                    Address = "Avenida Portugal, 5372 - Itapoã - Belo Horizone-MG",
                    Complement = null,
                    Number = 5372,
                    PostalCode = "31710-400",
                    CityId = 13
                },
                new Manufacturer
                {
                    Id = 10,
                    ShortName = "LTD",
                    FullName = "LTD Company, Ltda.",
                    CNPJ = "91.831.436/0001-88",
                    Phone = "(71) 3498-8862",
                    Email = "contato@ltd.com.br",
                    Address = "Rua Ozi Miranda, 3478 - Itapuã - Salvador-BA",
                    Complement = null,
                    Number = 3478,
                    PostalCode = "41650-066",
                    CityId = 5
                });
        }

        private void SeedProviders()
        {
            db.Providers.AddOrUpdate(p => p.Id,
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
                },
                new Provider
                {
                    Id = 3,
                    ShortName = "Playtech",
                    FullName = "Playtech Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "80.526.328/0001-85",
                    Phone = "(11) 3224-6244",
                    Email = "contato@playtech.com.br",
                    Address = "Rua Santa Ifigênia, 250 - Centro Histórico de São Paulo - São Paulo-SP",
                    Complement = null,
                    Number = 250,
                    PostalCode = "01207-000",
                    CityId = 25
                },
                new Provider
                {
                    Id = 4,
                    ShortName = "Musicaster",
                    FullName = "Musicaster Instrumentos Musicais, Ltda.",
                    CNPJ = "94.121.266/0001-36",
                    Phone = "(41) 3227-4951",
                    Email = "contato@musicaster.com.br",
                    Address = "Av. Anita Garibaldi, 621 - Cabral - Curitiba-PR",
                    Complement = null,
                    Number = 621,
                    PostalCode = "80540-180",
                    CityId = 16
                },
                new Provider
                {
                    Id = 5,
                    ShortName = "SonicSound",
                    FullName = "SonicSound Music, Ltda.",
                    CNPJ = "43.660.756/0001-70",
                    Phone = "(51) 3222-7822",
                    Email = "contato@sonicsound.com.br",
                    Address = "Av. Brasil, 6712 - Boqueirão - Porto Alegre-RS",
                    Complement = null,
                    Number = 6712,
                    PostalCode = "29023-180",
                    CityId = 21
                },
                new Provider
                {
                    Id = 6,
                    ShortName = "MusicMaker",
                    FullName = "MusicMaker, Ltda.",
                    CNPJ = "89.828.156/0001-79",
                    Phone = "(12) 3028-2188",
                    Email = "contato@musicmaker.com.br",
                    Address = "Av. João Pessoa, 2932 - Santa Felicidade - Fortaleza-CE",
                    Complement = null,
                    Number = 2932,
                    PostalCode = "21312-322",
                    CityId = 6
                },
                new Provider
                {
                    Id = 7,
                    ShortName = "PlayMusic",
                    FullName = "PlayMusic Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "77.528.894/0001-11",
                    Phone = "(44) 3091-8951",
                    Email = "contato@playmusic.com.br",
                    Address = "Rua Joubert de Carvalho, 372 - Zona 01 - Maringá-PR",
                    Complement = null,
                    Number = 372,
                    PostalCode = "87013-200",
                    CityId = 28
                },
                new Provider
                {
                    Id = 8,
                    ShortName = "BarraMusic",
                    FullName = "BarraMusic Instrumentos Musicais, Ltda.",
                    CNPJ = "65.355.838/0001-43",
                    Phone = "(21) 3325-2881",
                    Email = "contato@barramusic.com.br",
                    Address = "Avenida das Américas, 4790 - Barra da Tijuca - Rio de Janeiro-RJ",
                    Complement = null,
                    Number = 4790,
                    PostalCode = "22640-102",
                    CityId = 19
                },
                new Provider
                {
                    Id = 9,
                    ShortName = "Armazém do Músico",
                    FullName = "Armazém do Músico Instrumentos Musicais, Ltda.",
                    CNPJ = "76.382.755/0001-60",
                    Phone = "(43) 99910-5570",
                    Email = "contato@armazemdomusico.com.br",
                    Address = "Rua Lucineide Rodrigues Silveira, 119 - Conjunto Vivi Xavier - Londrina-PR",
                    Complement = null,
                    Number = 119,
                    PostalCode = "86082-860",
                    CityId = 31
                },
                new Provider
                {
                    Id = 10,
                    ShortName = "Roadie Store",
                    FullName = "Roadie Store Instrumentos Musicais, Ltda.",
                    CNPJ = "13.635.123/0001-40",
                    Phone = "(48) 3207-0174",
                    Email = "contato@roadiestore.com.br",
                    Address = "Rua Mané Vicente, 1144 - Monte Verde - Florianópolis-SC",
                    Complement = null,
                    Number = 1144,
                    PostalCode = "88032-600",
                    CityId = 24
                });
        }

        private void SeedProducts()
        {
            db.Products.AddOrUpdate(p => p.Id,
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
                },
                new Product
                {
                    Id = 5,
                    Description = "Baixo Fender Precision Bass Deluxe 4072 Ash",
                    PurchasePrice = 3447.00,
                    SalePrice = 10341.00,
                    Stock = 3,
                    Weight = 2.4,
                    Expiration = null,
                    CategoryId = 3,
                    ManufacturerId = 1,
                    ProviderId = 1,
                    UnitId = 1
                },
                new Product
                {
                    Id = 6,
                    Description = "Baixo MusicMan Sterling Ray 5",
                    PurchasePrice = 1200.00,
                    SalePrice = 3600.00,
                    Stock = 12,
                    Weight = 2.7,
                    Expiration = null,
                    CategoryId = 3,
                    ManufacturerId = 7,
                    ProviderId = 4,
                    UnitId = 1
                },
                new Product
                {
                    Id = 7,
                    Description = "Guitarra Fender JazzMaster '59 Reissue",
                    PurchasePrice = 1150.00,
                    SalePrice = 3450.00,
                    Stock = 5,
                    Weight = 2.9,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 5,
                    UnitId = 1
                },
                new Product
                {
                    Id = 8,
                    Description = "Guitarra Fender Telecaster B-Bender American Standard",
                    PurchasePrice = 2000.00,
                    SalePrice = 6000.00,
                    Stock = 2,
                    Weight = 2.8,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 6,
                    UnitId = 1
                },
                new Product
                {
                    Id = 9,
                    Description = "Guitarra Gibson SG Faded Worn Brown",
                    PurchasePrice = 2120.00,
                    SalePrice = 6360.00,
                    Stock = 7,
                    Weight = 3.5,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    ProviderId = 7,
                    UnitId = 1
                },
                new Product
                {
                    Id = 10,
                    Description = "Guitarra Fender Mustang Olympic White",
                    PurchasePrice = 1624.00,
                    SalePrice = 4872.00,
                    Stock = 1,
                    Weight = 3,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 8,
                    UnitId = 1
                });
        }

        private void SeedUsers()
        {
            db.Users.AddOrUpdate(u => u.Id,
                new User
                {
                    Id = 1,
                    Name = "Douglas",
                    LastName = "Mezuraro",
                    CPF = "101.202.303-40",
                    Birth = System.DateTime.Parse("18/06/1996"),
                    Gender = Gender.Male,
                    Phone = "(44) 99947-7765",
                    Email = "douglasmez@gmail.com",
                    Password = "1",
                    UserType = UserType.Admin,
                    Address = "Rua Toledo",
                    Number = 812,
                    PostalCode = "87053-518",
                    CityId = 28
                },
                new User
                {
                    Id = 2,
                    Name = "Pedro",
                    LastName = "Pedro Fábio Rocha",
                    CPF = "756.116.050-01",
                    Birth = System.DateTime.Parse("06/03/1946"),
                    Gender = Gender.Male,
                    Phone = "(68) 2528-3606",
                    Email = "pedro@gmail.com.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Travessa Calvário",
                    Number = 250,
                    PostalCode = "69914-322",
                    CityId = 1
                },
                new User
                {
                    Id = 3,
                    Name = "Laura",
                    LastName = "Benedita Bruna Farias",
                    CPF = "874.164.752-10",
                    Birth = System.DateTime.Parse("12/06/1978"),
                    Gender = Gender.Female,
                    Phone = "(82) 3836-8906",
                    Email = "mikael@akerfeldt.com",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Rua Atalaia",
                    Number = 945,
                    PostalCode = "57045-020",
                    CityId = 2
                },
                new User
                {
                    Id = 4,
                    Name = "Gabriel",
                    LastName = "Nathan Bernardes",
                    CPF = "147.020.382-06",
                    Birth = System.DateTime.Parse("27/01/1992"),
                    Gender = Gender.Male,
                    Phone = "(92) 2550-9909",
                    Email = "gabriel.bernardes@tia.mat.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Rua Álvaro Fernandes",
                    Number = 323,
                    PostalCode = "69077-640",
                    CityId = 3
                },
                new User
                {
                    Id = 5,
                    Name = "Sophia",
                    LastName = "Rayssa Isabelle Figueiredo",
                    CPF = "036.435.222-15",
                    Birth = System.DateTime.Parse("03/09/1994"),
                    Gender = Gender.Female,
                    Phone = "(96) 3961-5891",
                    Email = "sophia.figueiredo@samsaraimoveis.com.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Passagem Jorge Basile",
                    Number = 677,
                    PostalCode = "68908-890",
                    CityId = 4
                },
                new User
                {
                    Id = 6,
                    Name = "Noah",
                    LastName = "Diego Cruz",
                    CPF = "272.300.965-37",
                    Birth = System.DateTime.Parse("09/09/1981"),
                    Gender = Gender.Male,
                    Phone = "(71) 2837-2714",
                    Email = "noah.cruz@munhozengenharia.com.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Rua Pedro Gama",
                    Number = 185,
                    PostalCode = "40231-901",
                    CityId = 5
                },
                new User
                {
                    Id = 7,
                    Name = "Sophia",
                    LastName = "Sophie Cristiane Pires",
                    CPF = "388.492.673-04",
                    Birth = System.DateTime.Parse("13/04/1940"),
                    Gender = Gender.Male,
                    Phone = "(85) 3730-5610",
                    Email = "sophia.pires@dafitex.com.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Rua Zenaide",
                    Number = 1923,
                    PostalCode = "60130-030",
                    CityId = 6
                },
                new User
                {
                    Id = 8,
                    Name = "Rafael",
                    LastName = "Thales de Almeida",
                    CPF = "751.864.680-37",
                    Birth = System.DateTime.Parse("04/09/1956"),
                    Gender = Gender.Male,
                    Phone = "(61) 2847-5619",
                    Email = "rafaelthalesalmeida-71@gmx.ca",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Rua Pinheirinho",
                    Number = 7121,
                    PostalCode = "72260-825",
                    CityId = 7
                },
                new User
                {
                    Id = 9,
                    Name = "Carolina",
                    LastName = "Aline Sales",
                    CPF = "338.065.340-39",
                    Birth = System.DateTime.Parse("23/04/1989"),
                    Gender = Gender.Female,
                    Phone = "(27) 2691-7894",
                    Email = "carolina.sales@tarp.com.br",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Praça Padre Francisco Alberst",
                    Number = 8123,
                    PostalCode = "29263-980",
                    CityId = 8
                },
                new User
                {
                    Id = 10,
                    Name = "Antônia",
                    LastName = "Giovanna Nair Novaes",
                    CPF = "623.107.310-64",
                    Birth = System.DateTime.Parse("06/02/1957"),
                    Gender = Gender.Female,
                    Phone = "(62) 2566-7484",
                    Email = "antonia.nair.57@yahoo.com",
                    Password = "1",
                    UserType = UserType.Customer,
                    Address = "Avenida Araguaia",
                    Number = 406,
                    PostalCode = "74030-100",
                    CityId = 9
                });
        }
    }
}
