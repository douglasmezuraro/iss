using PSS.Models;
using SGCO.Context;
using System.Data.Entity.Migrations;

namespace PSS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        private DBContext _context;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DBContext context)
        {
            _context = context;

            ResetDatabase();
            ResetSequences();

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

        private void ResetDatabase()
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM Items;");
            _context.Database.ExecuteSqlCommand("DELETE FROM PurchaseOrderFreights;");
            _context.Database.ExecuteSqlCommand("DELETE FROM PurchaseOrderPayments;");
            _context.Database.ExecuteSqlCommand("DELETE FROM PurchaseOrders;");
            _context.Database.ExecuteSqlCommand("DELETE FROM SaleOrderFreights;");
            _context.Database.ExecuteSqlCommand("DELETE FROM SaleOrderPayments;");
            _context.Database.ExecuteSqlCommand("DELETE FROM SaleOrders;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Products;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Units;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Categories;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Manufacturers;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Providers;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Users;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Cities;");
            _context.Database.ExecuteSqlCommand("DELETE FROM States;");
            _context.Database.ExecuteSqlCommand("DELETE FROM Countries;");
        }

        private void ResetSequences()
        {
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Categories', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Cities', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Countries', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Items', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Manufacturers', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Products', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Providers', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('PurchaseOrderFreights', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('PurchaseOrderPayments', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('PurchaseOrders', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SaleOrderFreights', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SaleOrderPayments', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SaleOrders', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('States', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Units', RESEED, 0);");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Users', RESEED, 0);");
        }

        private void SeedCountries()
        {
            _context.Countries.AddOrUpdate(c => c.Id,
                new Country { Id = 001, Name = "Afeganistão" },
                new Country { Id = 002, Name = "África do Sul" },
                new Country { Id = 003, Name = "Albânia" },
                new Country { Id = 004, Name = "Alemanha" },
                new Country { Id = 005, Name = "Andorra" },
                new Country { Id = 006, Name = "Angola" },
                new Country { Id = 007, Name = "Antiga e Barbuda" },
                new Country { Id = 008, Name = "Arábia Saudita" },
                new Country { Id = 009, Name = "Argélia" },
                new Country { Id = 010, Name = "Argentina" },
                new Country { Id = 011, Name = "Arménia" },
                new Country { Id = 012, Name = "Austrália" },
                new Country { Id = 013, Name = "Áustria" },
                new Country { Id = 014, Name = "Azerbaijão" },
                new Country { Id = 015, Name = "Bahamas" },
                new Country { Id = 016, Name = "Bangladexe" },
                new Country { Id = 017, Name = "Barbados" },
                new Country { Id = 018, Name = "Barém" },
                new Country { Id = 019, Name = "Bélgica" },
                new Country { Id = 020, Name = "Belize" },
                new Country { Id = 021, Name = "Benim" },
                new Country { Id = 022, Name = "Bielorrússia" },
                new Country { Id = 023, Name = "Bolívia" },
                new Country { Id = 024, Name = "Bósnia e Herzegovina" },
                new Country { Id = 025, Name = "Botsuana" },
                new Country { Id = 026, Name = "Brasil" },
                new Country { Id = 027, Name = "Brunei" },
                new Country { Id = 028, Name = "Bulgária" },
                new Country { Id = 029, Name = "Burquina Faso" },
                new Country { Id = 030, Name = "Burúndi" },
                new Country { Id = 031, Name = "Butão" },
                new Country { Id = 032, Name = "Cabo Verde" },
                new Country { Id = 033, Name = "Camarões" },
                new Country { Id = 034, Name = "Camboja" },
                new Country { Id = 035, Name = "Canadá" },
                new Country { Id = 036, Name = "Catar" },
                new Country { Id = 037, Name = "Cazaquistão" },
                new Country { Id = 038, Name = "Chade" },
                new Country { Id = 039, Name = "Chile" },
                new Country { Id = 040, Name = "China" },
                new Country { Id = 041, Name = "Chipre" },
                new Country { Id = 042, Name = "Colômbia" },
                new Country { Id = 043, Name = "Comores" },
                new Country { Id = 044, Name = "Congo-Brazzaville" },
                new Country { Id = 045, Name = "Coreia do Norte" },
                new Country { Id = 046, Name = "Coreia do Sul" },
                new Country { Id = 047, Name = "Cosovo" },
                new Country { Id = 048, Name = "Costa do Marfim" },
                new Country { Id = 049, Name = "Costa Rica" },
                new Country { Id = 050, Name = "Croácia" },
                new Country { Id = 051, Name = "Cuaite" },
                new Country { Id = 052, Name = "Cuba" },
                new Country { Id = 053, Name = "Dinamarca" },
                new Country { Id = 054, Name = "Dominica" },
                new Country { Id = 055, Name = "Egito" },
                new Country { Id = 056, Name = "Emirados Árabes Unidos" },
                new Country { Id = 057, Name = "Equador" },
                new Country { Id = 058, Name = "Eritreia" },
                new Country { Id = 059, Name = "Eslováquia" },
                new Country { Id = 060, Name = "Eslovénia" },
                new Country { Id = 061, Name = "Espanha" },
                new Country { Id = 062, Name = "Estado da Palestina" },
                new Country { Id = 063, Name = "Estados Unidos" },
                new Country { Id = 064, Name = "Estónia" },
                new Country { Id = 065, Name = "Etiópia" },
                new Country { Id = 066, Name = "Fiji" },
                new Country { Id = 067, Name = "Filipinas" },
                new Country { Id = 068, Name = "Finlândia" },
                new Country { Id = 069, Name = "França" },
                new Country { Id = 070, Name = "Gabão" },
                new Country { Id = 071, Name = "Gâmbia" },
                new Country { Id = 072, Name = "Gana" },
                new Country { Id = 073, Name = "Geórgia" },
                new Country { Id = 074, Name = "Granada" },
                new Country { Id = 075, Name = "Grécia" },
                new Country { Id = 076, Name = "Guatemala" },
                new Country { Id = 077, Name = "Guiana" },
                new Country { Id = 078, Name = "Guiné" },
                new Country { Id = 079, Name = "Guiné Equatorial" },
                new Country { Id = 080, Name = "Guiné-Bissau" },
                new Country { Id = 081, Name = "Haiti" },
                new Country { Id = 082, Name = "Honduras" },
                new Country { Id = 083, Name = "Hungria" },
                new Country { Id = 084, Name = "Iémen" },
                new Country { Id = 085, Name = "Ilhas Marechal" },
                new Country { Id = 086, Name = "Índia" },
                new Country { Id = 087, Name = "Indonésia" },
                new Country { Id = 088, Name = "Irão" },
                new Country { Id = 089, Name = "Iraque" },
                new Country { Id = 090, Name = "Irlanda" },
                new Country { Id = 091, Name = "Islândia" },
                new Country { Id = 092, Name = "Israel" },
                new Country { Id = 093, Name = "Itália" },
                new Country { Id = 094, Name = "Jamaica" },
                new Country { Id = 095, Name = "Japão" },
                new Country { Id = 096, Name = "Jibuti" },
                new Country { Id = 097, Name = "Jordânia" },
                new Country { Id = 098, Name = "Laus" },
                new Country { Id = 099, Name = "Lesoto" },
                new Country { Id = 100, Name = "Letónia" },
                new Country { Id = 101, Name = "Líbano" },
                new Country { Id = 102, Name = "Libéria" },
                new Country { Id = 103, Name = "Líbia" },
                new Country { Id = 104, Name = "Listenstaine" },
                new Country { Id = 105, Name = "Lituânia" },
                new Country { Id = 106, Name = "Luxemburgo" },
                new Country { Id = 107, Name = "Macedónia" },
                new Country { Id = 108, Name = "Madagáscar" },
                new Country { Id = 109, Name = "Malásia" },
                new Country { Id = 110, Name = "Maláui" },
                new Country { Id = 111, Name = "Maldivas" },
                new Country { Id = 112, Name = "Mali" },
                new Country { Id = 113, Name = "Malta" },
                new Country { Id = 114, Name = "Marrocos" },
                new Country { Id = 115, Name = "Maurícia" },
                new Country { Id = 116, Name = "Mauritânia" },
                new Country { Id = 117, Name = "México" },
                new Country { Id = 118, Name = "Mianmar" },
                new Country { Id = 119, Name = "Micronésia" },
                new Country { Id = 120, Name = "Moçambique" },
                new Country { Id = 121, Name = "Moldávia" },
                new Country { Id = 122, Name = "Mónaco" },
                new Country { Id = 123, Name = "Mongólia" },
                new Country { Id = 124, Name = "Montenegro" },
                new Country { Id = 125, Name = "Namíbia" },
                new Country { Id = 126, Name = "Nauru" },
                new Country { Id = 127, Name = "Nepal" },
                new Country { Id = 128, Name = "Nicarágua" },
                new Country { Id = 129, Name = "Níger" },
                new Country { Id = 130, Name = "Nigéria" },
                new Country { Id = 131, Name = "Noruega" },
                new Country { Id = 132, Name = "Nova Zelândia" },
                new Country { Id = 133, Name = "Omã" },
                new Country { Id = 134, Name = "Países Baixos" },
                new Country { Id = 135, Name = "Palau" },
                new Country { Id = 136, Name = "Panamá" },
                new Country { Id = 137, Name = "Papua Nova Guiné" },
                new Country { Id = 138, Name = "Paquistão" },
                new Country { Id = 139, Name = "Paraguai" },
                new Country { Id = 140, Name = "Peru" },
                new Country { Id = 141, Name = "Polónia" },
                new Country { Id = 142, Name = "Portugal" },
                new Country { Id = 143, Name = "Quénia" },
                new Country { Id = 144, Name = "Quirguistão" },
                new Country { Id = 145, Name = "Quiribáti" },
                new Country { Id = 146, Name = "Reino Unido" },
                new Country { Id = 147, Name = "República Centro-Africana" },
                new Country { Id = 148, Name = "República Checa" },
                new Country { Id = 149, Name = "República Democrática do Congo" },
                new Country { Id = 150, Name = "República Dominicana" },
                new Country { Id = 151, Name = "Roménia" },
                new Country { Id = 152, Name = "Ruanda" },
                new Country { Id = 153, Name = "Rússia" },
                new Country { Id = 154, Name = "Salomão" },
                new Country { Id = 155, Name = "Salvador" },
                new Country { Id = 156, Name = "Samoa" },
                new Country { Id = 157, Name = "Santa Lúcia" },
                new Country { Id = 158, Name = "São Cristóvão e Neves" },
                new Country { Id = 159, Name = "São Marinho" },
                new Country { Id = 160, Name = "São Tomé e Príncipe" },
                new Country { Id = 161, Name = "São Vicente e Granadinas" },
                new Country { Id = 162, Name = "Seicheles" },
                new Country { Id = 163, Name = "Senegal" },
                new Country { Id = 164, Name = "Serra Leoa" },
                new Country { Id = 165, Name = "Sérvia" },
                new Country { Id = 166, Name = "Singapura" },
                new Country { Id = 167, Name = "Síria" },
                new Country { Id = 168, Name = "Somália" },
                new Country { Id = 169, Name = "Sri Lanca" },
                new Country { Id = 170, Name = "Suazilândia" },
                new Country { Id = 171, Name = "Sudão" },
                new Country { Id = 172, Name = "Sudão do Sul" },
                new Country { Id = 173, Name = "Suécia" },
                new Country { Id = 174, Name = "Suíça" },
                new Country { Id = 175, Name = "Suriname" },
                new Country { Id = 176, Name = "Tailândia" },
                new Country { Id = 177, Name = "Taiuã" },
                new Country { Id = 178, Name = "Tajiquistão" },
                new Country { Id = 179, Name = "Tanzânia" },
                new Country { Id = 180, Name = "Timor-Leste" },
                new Country { Id = 181, Name = "Togo" },
                new Country { Id = 182, Name = "Tonga" },
                new Country { Id = 183, Name = "Trindade e Tobago" },
                new Country { Id = 184, Name = "Tunísia" },
                new Country { Id = 185, Name = "Turcomenistão" },
                new Country { Id = 186, Name = "Turquia" },
                new Country { Id = 187, Name = "Tuvalu" },
                new Country { Id = 188, Name = "Ucrânia" },
                new Country { Id = 189, Name = "Uganda" },
                new Country { Id = 190, Name = "Uruguai" },
                new Country { Id = 191, Name = "Usbequistão" },
                new Country { Id = 192, Name = "Vanuatu" },
                new Country { Id = 193, Name = "Vaticano" },
                new Country { Id = 194, Name = "Venezuela" },
                new Country { Id = 195, Name = "Vietname" },
                new Country { Id = 196, Name = "Zâmbia" },
                new Country { Id = 197, Name = "Zimbábue" });
        }

        private void SeedStates()
        {
            _context.States.AddOrUpdate(s => s.Id,
                new State { Id = 01, UF = "AC", CountryId = 26, Name = "Acre" },
                new State { Id = 02, UF = "AL", CountryId = 26, Name = "Alagoas" },
                new State { Id = 03, UF = "AP", CountryId = 26, Name = "Amapá" },
                new State { Id = 04, UF = "AM", CountryId = 26, Name = "Amazonas" },
                new State { Id = 05, UF = "BA", CountryId = 26, Name = "Bahia" },
                new State { Id = 06, UF = "CE", CountryId = 26, Name = "Ceará" },
                new State { Id = 07, UF = "DF", CountryId = 26, Name = "Distrito Federal" },
                new State { Id = 08, UF = "ES", CountryId = 26, Name = "Espírito Santo" },
                new State { Id = 09, UF = "GO", CountryId = 26, Name = "Goiás" },
                new State { Id = 10, UF = "MA", CountryId = 26, Name = "Maranhão" },
                new State { Id = 11, UF = "MT", CountryId = 26, Name = "Mato Grosso" },
                new State { Id = 12, UF = "MS", CountryId = 26, Name = "Mato Grosso do Sul" },
                new State { Id = 13, UF = "MG", CountryId = 26, Name = "Minas Gerais" },
                new State { Id = 14, UF = "PA", CountryId = 26, Name = "Pará" },
                new State { Id = 15, UF = "PB", CountryId = 26, Name = "Paraíba" },
                new State { Id = 16, UF = "PR", CountryId = 26, Name = "Paraná" },
                new State { Id = 17, UF = "PE", CountryId = 26, Name = "Pernambuco" },
                new State { Id = 18, UF = "PI", CountryId = 26, Name = "Piauí" },
                new State { Id = 19, UF = "RJ", CountryId = 26, Name = "Rio de Janeiro" },
                new State { Id = 20, UF = "RN", CountryId = 26, Name = "Rio Grande do Norte" },
                new State { Id = 21, UF = "RS", CountryId = 26, Name = "Rio Grande do Sul" },
                new State { Id = 22, UF = "RO", CountryId = 26, Name = "Rondônia" },
                new State { Id = 23, UF = "RR", CountryId = 26, Name = "Roraima" },
                new State { Id = 24, UF = "SC", CountryId = 26, Name = "Santa Catarina" },
                new State { Id = 25, UF = "SP", CountryId = 26, Name = "São Paulo" },
                new State { Id = 26, UF = "SE", CountryId = 26, Name = "Sergipe" },
                new State { Id = 27, UF = "TO", CountryId = 26, Name = "Tocantins" },
                new State { Id = 28, UF = "AL", CountryId = 63, Name = "Alabama" },
                new State { Id = 29, UF = "AK", CountryId = 63, Name = "Alasca" },
                new State { Id = 30, UF = "AR", CountryId = 63, Name = "Arcansas" },
                new State { Id = 31, UF = "AZ", CountryId = 63, Name = "Arizona" },
                new State { Id = 32, UF = "CA", CountryId = 63, Name = "Califórnia" },
                new State { Id = 33, UF = "KS", CountryId = 63, Name = "Cansas" },
                new State { Id = 34, UF = "NC", CountryId = 63, Name = "Carolina do Norte" },
                new State { Id = 35, UF = "SC", CountryId = 63, Name = "Carolina do Sul" },
                new State { Id = 36, UF = "CO", CountryId = 63, Name = "Colorado" },
                new State { Id = 37, UF = "CT", CountryId = 63, Name = "Conecticute" },
                new State { Id = 38, UF = "ND", CountryId = 63, Name = "Dakota do Norte" },
                new State { Id = 39, UF = "SD", CountryId = 63, Name = "Dakota do Sul" },
                new State { Id = 40, UF = "DE", CountryId = 63, Name = "Delaware" },
                new State { Id = 41, UF = "FL", CountryId = 63, Name = "Flórida" },
                new State { Id = 42, UF = "GA", CountryId = 63, Name = "Geórgia" },
                new State { Id = 43, UF = "HI", CountryId = 63, Name = "Havaí" },
                new State { Id = 44, UF = "ID", CountryId = 63, Name = "Idaho" },
                new State { Id = 45, UF = "RI", CountryId = 63, Name = "Ilha de Rodes" },
                new State { Id = 46, UF = "IL", CountryId = 63, Name = "Ilinóis" },
                new State { Id = 47, UF = "IN", CountryId = 63, Name = "Indiana" },
                new State { Id = 48, UF = "IA", CountryId = 63, Name = "Iowa" },
                new State { Id = 49, UF = "KY", CountryId = 63, Name = "Kentucky" },
                new State { Id = 50, UF = "LA", CountryId = 63, Name = "Luisiana" },
                new State { Id = 51, UF = "ME", CountryId = 63, Name = "Maine" },
                new State { Id = 52, UF = "MD", CountryId = 63, Name = "Marilândia" },
                new State { Id = 53, UF = "MA", CountryId = 63, Name = "Massachusetts" },
                new State { Id = 54, UF = "MI", CountryId = 63, Name = "Míchigan" },
                new State { Id = 55, UF = "MN", CountryId = 63, Name = "Minesota" },
                new State { Id = 56, UF = "MS", CountryId = 63, Name = "Mississípi" },
                new State { Id = 57, UF = "MO", CountryId = 63, Name = "Missúri" },
                new State { Id = 58, UF = "MT", CountryId = 63, Name = "Montana" },
                new State { Id = 59, UF = "NE", CountryId = 63, Name = "Nebrasca" },
                new State { Id = 60, UF = "NV", CountryId = 63, Name = "Nevada" },
                new State { Id = 61, UF = "NH", CountryId = 63, Name = "Nova Hampshire" },
                new State { Id = 62, UF = "NJ", CountryId = 63, Name = "Nova Jérsei" },
                new State { Id = 63, UF = "NY", CountryId = 63, Name = "Nova Iorque" },
                new State { Id = 64, UF = "NM", CountryId = 63, Name = "Novo México" },
                new State { Id = 65, UF = "OK", CountryId = 63, Name = "Oclaoma" },
                new State { Id = 66, UF = "OH", CountryId = 63, Name = "Ohio" },
                new State { Id = 67, UF = "OR", CountryId = 63, Name = "Óregon" },
                new State { Id = 68, UF = "PA", CountryId = 63, Name = "Pensilvânia" },
                new State { Id = 69, UF = "TN", CountryId = 63, Name = "Tenessi" },
                new State { Id = 70, UF = "TX", CountryId = 63, Name = "Texas" },
                new State { Id = 71, UF = "UT", CountryId = 63, Name = "Utá" },
                new State { Id = 72, UF = "VT", CountryId = 63, Name = "Vermonte" },
                new State { Id = 73, UF = "VA", CountryId = 63, Name = "Virgínia" },
                new State { Id = 74, UF = "WV", CountryId = 63, Name = "Virgínia Ocidental" },
                new State { Id = 75, UF = "WA", CountryId = 63, Name = "Washington" },
                new State { Id = 76, UF = "WI", CountryId = 63, Name = "Wisconsin" },
                new State { Id = 77, UF = "WY", CountryId = 63, Name = "Wyoming" });
        }

        private void SeedCities()
        {
            _context.Cities.AddOrUpdate(c => c.Id,
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
                new City { Id = 31, StateId = 16, Name = "Londrina" },
                new City { Id = 32, StateId = 28, Name = "Montgomery" },
                new City { Id = 33, StateId = 29, Name = "Juneau" },
                new City { Id = 34, StateId = 30, Name = "Little Rock" },
                new City { Id = 35, StateId = 31, Name = "Phoenix" },
                new City { Id = 36, StateId = 32, Name = "Sacramento" },
                new City { Id = 37, StateId = 33, Name = "Topeka" },
                new City { Id = 38, StateId = 34, Name = "Raleigh" },
                new City { Id = 39, StateId = 35, Name = "Columbia" },
                new City { Id = 40, StateId = 36, Name = "Denver" },
                new City { Id = 41, StateId = 37, Name = "Hartford" },
                new City { Id = 42, StateId = 38, Name = "Bismarck" },
                new City { Id = 43, StateId = 39, Name = "Pierre" },
                new City { Id = 44, StateId = 40, Name = "Dover" },
                new City { Id = 45, StateId = 41, Name = "Tallahassee" },
                new City { Id = 46, StateId = 42, Name = "Atlanta" },
                new City { Id = 47, StateId = 43, Name = "Honolulu" },
                new City { Id = 48, StateId = 44, Name = "Boise" },
                new City { Id = 49, StateId = 45, Name = "Providence" },
                new City { Id = 50, StateId = 46, Name = "Springfield" },
                new City { Id = 51, StateId = 47, Name = "Indianápolis" },
                new City { Id = 52, StateId = 48, Name = "Des Moines" },
                new City { Id = 53, StateId = 49, Name = "Frankfort" },
                new City { Id = 54, StateId = 50, Name = "Baton Rouge" },
                new City { Id = 55, StateId = 51, Name = "Augusta" },
                new City { Id = 56, StateId = 52, Name = "Annapolis" },
                new City { Id = 57, StateId = 53, Name = "Boston" },
                new City { Id = 58, StateId = 54, Name = "Lansing" },
                new City { Id = 59, StateId = 55, Name = "Saint Paul" },
                new City { Id = 60, StateId = 56, Name = "Jackson" },
                new City { Id = 61, StateId = 57, Name = "Jefferson City" },
                new City { Id = 62, StateId = 58, Name = "Helena" },
                new City { Id = 63, StateId = 59, Name = "Lincoln" },
                new City { Id = 64, StateId = 60, Name = "Carson City" },
                new City { Id = 65, StateId = 61, Name = "Concord" },
                new City { Id = 66, StateId = 62, Name = "Trenton" },
                new City { Id = 67, StateId = 63, Name = "Albany" },
                new City { Id = 68, StateId = 64, Name = "Santa Fe" },
                new City { Id = 69, StateId = 65, Name = "Oklahoma City" },
                new City { Id = 70, StateId = 66, Name = "Columbus" },
                new City { Id = 71, StateId = 67, Name = "Salem" },
                new City { Id = 72, StateId = 68, Name = "Harrisburg" },
                new City { Id = 73, StateId = 69, Name = "Nashville" },
                new City { Id = 74, StateId = 70, Name = "Austin" },
                new City { Id = 75, StateId = 71, Name = "Salt Lake City" },
                new City { Id = 76, StateId = 72, Name = "Montpelier" },
                new City { Id = 77, StateId = 73, Name = "Richmond" },
                new City { Id = 78, StateId = 74, Name = "Charleston" },
                new City { Id = 79, StateId = 75, Name = "Olympia" },
                new City { Id = 80, StateId = 76, Name = "Madison" },
                new City { Id = 81, StateId = 77, Name = "Cheyenne" },
                new City { Id = 82, StateId = 25, Name = "Salto" });
        }

        private void SeedUnits()
        {
            _context.Units.AddOrUpdate(u => u.Id,
                new Unit { Id = 01, Abbreviation = "AMPOLA", Description = "Ampola" },
                new Unit { Id = 02, Abbreviation = "BALDE", Description = "Balde" },
                new Unit { Id = 03, Abbreviation = "BANDEJ", Description = "Bandeja" },
                new Unit { Id = 04, Abbreviation = "BARRA", Description = "Barra" },
                new Unit { Id = 05, Abbreviation = "BISNAG", Description = "Bisnaga" },
                new Unit { Id = 06, Abbreviation = "BLOCO", Description = "Bloco" },
                new Unit { Id = 07, Abbreviation = "BOBINA", Description = "Bobina" },
                new Unit { Id = 08, Abbreviation = "BOMB", Description = "Bombona" },
                new Unit { Id = 09, Abbreviation = "CAPS", Description = "Capsula" },
                new Unit { Id = 10, Abbreviation = "CART", Description = "Cartela" },
                new Unit { Id = 11, Abbreviation = "CENTO", Description = "Cento" },
                new Unit { Id = 12, Abbreviation = "CJ", Description = "Conjunto" },
                new Unit { Id = 13, Abbreviation = "CM", Description = "Centímetro" },
                new Unit { Id = 14, Abbreviation = "CM2", Description = "Centímetro Quadrado" },
                new Unit { Id = 15, Abbreviation = "CX", Description = "Caixa" },
                new Unit { Id = 16, Abbreviation = "CX2", Description = "Caixa Com 2 Unidades" },
                new Unit { Id = 17, Abbreviation = "CX3", Description = "Caixa Com 3 Unidades" },
                new Unit { Id = 18, Abbreviation = "CX5", Description = "Caixa Com 5 Unidades" },
                new Unit { Id = 19, Abbreviation = "CX10", Description = "Caixa Com 10 Unidades" },
                new Unit { Id = 20, Abbreviation = "CX15", Description = "Caixa Com 15 Unidades" },
                new Unit { Id = 21, Abbreviation = "CX20", Description = "Caixa Com 20 Unidades" },
                new Unit { Id = 22, Abbreviation = "CX25", Description = "Caixa Com 25 Unidades" },
                new Unit { Id = 23, Abbreviation = "CX50", Description = "Caixa Com 50 Unidades" },
                new Unit { Id = 24, Abbreviation = "CX100", Description = "Caixa Com 100 Unidades" },
                new Unit { Id = 25, Abbreviation = "DISP", Description = "Display" },
                new Unit { Id = 26, Abbreviation = "DUZIA", Description = "Duzia" },
                new Unit { Id = 27, Abbreviation = "EMBAL", Description = "Embalagem" },
                new Unit { Id = 28, Abbreviation = "FARDO", Description = "Fardo" },
                new Unit { Id = 29, Abbreviation = "FOLHA", Description = "Folha" },
                new Unit { Id = 30, Abbreviation = "FRASCO", Description = "Frasco" },
                new Unit { Id = 31, Abbreviation = "GALAO", Description = "Galão" },
                new Unit { Id = 32, Abbreviation = "GF", Description = "Garrafa" },
                new Unit { Id = 33, Abbreviation = "GRAMAS", Description = "Gramas" },
                new Unit { Id = 34, Abbreviation = "JOGO", Description = "Jogo" },
                new Unit { Id = 35, Abbreviation = "KG", Description = "Quilograma" },
                new Unit { Id = 36, Abbreviation = "KIT", Description = "Kit" },
                new Unit { Id = 37, Abbreviation = "LATA", Description = "Lata" },
                new Unit { Id = 38, Abbreviation = "LITRO", Description = "Litro" },
                new Unit { Id = 39, Abbreviation = "M", Description = "Metro" },
                new Unit { Id = 40, Abbreviation = "M2", Description = "Metro Quadrado" },
                new Unit { Id = 41, Abbreviation = "M3", Description = "Metro Cúbico" },
                new Unit { Id = 42, Abbreviation = "MILHEI", Description = "Milheiro" },
                new Unit { Id = 43, Abbreviation = "ML", Description = "Mililitro" },
                new Unit { Id = 44, Abbreviation = "MWH", Description = "Megawatt Hora" },
                new Unit { Id = 45, Abbreviation = "PACOTE", Description = "Pacote" },
                new Unit { Id = 46, Abbreviation = "PALETE", Description = "Palete" },
                new Unit { Id = 47, Abbreviation = "PARES", Description = "Pares" },
                new Unit { Id = 48, Abbreviation = "PC", Description = "Peça" },
                new Unit { Id = 49, Abbreviation = "POTE", Description = "Pote" },
                new Unit { Id = 50, Abbreviation = "K", Description = "Quilate" },
                new Unit { Id = 51, Abbreviation = "RESMA", Description = "Resma" },
                new Unit { Id = 52, Abbreviation = "ROLO", Description = "Rolo" },
                new Unit { Id = 53, Abbreviation = "SACO", Description = "Saco" },
                new Unit { Id = 54, Abbreviation = "SACOLA", Description = "Sacola" },
                new Unit { Id = 55, Abbreviation = "TAMBOR", Description = "Tambor" },
                new Unit { Id = 56, Abbreviation = "TANQUE", Description = "Tanque" },
                new Unit { Id = 57, Abbreviation = "TON", Description = "Tonelada" },
                new Unit { Id = 58, Abbreviation = "TUBO", Description = "Tubo" },
                new Unit { Id = 59, Abbreviation = "UNID", Description = "Unidade" },
                new Unit { Id = 60, Abbreviation = "VASIL", Description = "Vasilhame" },
                new Unit { Id = 61, Abbreviation = "VIDRO", Description = "Vidro" });
        }

        private void SeedCategories()
        {
            _context.Categories.AddOrUpdate(c => c.Id,
                new Category { Id = 01, Name = "Guitarra" },
                new Category { Id = 02, Name = "Violão" },
                new Category { Id = 03, Name = "Baixo" },
                new Category { Id = 04, Name = "Bateria" },
                new Category { Id = 05, Name = "Teclado" },
                new Category { Id = 06, Name = "Piano" },
                new Category { Id = 07, Name = "Saxofone" },
                new Category { Id = 08, Name = "Amplificador" },
                new Category { Id = 09, Name = "Pedal" });
        }

        private void SeedManufacturers()
        {
            _context.Manufacturers.AddOrUpdate(m => m.Id,
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
                },
                new Manufacturer
                {
                    Id = 11,
                    ShortName = "SX",
                    FullName = "SX Instruments Ltda.",
                    CNPJ = "12.860.645/0001-83",
                    Phone = "(11) 3228-1275",
                    Email = "contato@sx.com.br",
                    Address = "Avenida Ruy Barbosa, 213 - Vila Mariana - São Paulo-SP",
                    Complement = null,
                    Number = 213,
                    PostalCode = "02612-000",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 12,
                    ShortName = "Giannini",
                    FullName = "Giannini Instrumentos Musicais Ltda.",
                    CNPJ = "54.343.154/0001-05",
                    Phone = "(11) 3227-4951",
                    Email = "contato@giannini.com",
                    Address = "Avenida Tranquillo Giannini, 700 - Distrito Industrial - Salto",
                    Complement = null,
                    Number = 700,
                    PostalCode = "13329-600",
                    CityId = 25//82
                },
                new Manufacturer
                {
                    Id = 13,
                    ShortName = "Epiphone",
                    FullName = "The Epiphone Company",
                    CNPJ = "82.234.408/0001-92",
                    Phone = "(11) 2190-1281",
                    Email = "contato@epiphone.com.br",
                    Address = "Av. Jabaquara, 2049 - Mirandópolis - São Paulo-SP",
                    Complement = null,
                    Number = 2049,
                    PostalCode = "04045-003",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 14,
                    ShortName = "Squier",
                    FullName = "Squier Musical Instruments by Fender",
                    CNPJ = "46.918.108/0001-69",
                    Phone = "(11) 3222-4922",
                    Email = "contato@squier.com.br",
                    Address = "Rua Arandu, 205 - Brooklin Novo - São Paulo-SP",
                    Complement = "Ed. Berrini Business Center",
                    Number = 205,
                    PostalCode = "04562-030",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 15,
                    ShortName = "Jackson",
                    FullName = "Jackson Guitars",
                    CNPJ = "55.743.338/0001-25",
                    Phone = "(11) 3218-0012",
                    Email = "contato@jackson.com.br",
                    Address = "Rua Jacarandá, 9892 - Jabaquara - São Paulo-SP",
                    Complement = null,
                    Number = 9892,
                    PostalCode = "00112-092",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 16,
                    ShortName = "Schecter",
                    FullName = "Schecter Guitar Research",
                    CNPJ = "53.496.743/0001-60",
                    Phone = "(11) 3222-1219",
                    Email = "contato@schecter.com.br",
                    Address = "Avenida das Palmeiras, 1401 - Liberdade - São Paulo-SP",
                    Complement = null,
                    Number = 1401,
                    PostalCode = "00912-982",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 17,
                    ShortName = "Zildjian",
                    FullName = "Avedis Zildjian Company",
                    CNPJ = "06.327.673/0001-37",
                    Phone = "(41) 3713-2566",
                    Email = "contato@zildjian.com.br",
                    Address = "Rua das Acácias, 941 - Barreirinha - Curitiba-PR",
                    Complement = null,
                    Number = 941,
                    PostalCode = "82700-320",
                    CityId = 16
                },
                new Manufacturer
                {
                    Id = 18,
                    ShortName = "Tama Drums",
                    FullName = "Tama Drums",
                    CNPJ = "43.243.843/0001-21",
                    Phone = "(51) 2102-1231",
                    Email = "contato@tama.com.br",
                    Address = "Rua Américo Vespucio, 111 - Higienópolis - Porto Alegre-RS",
                    Complement = null,
                    Number = 111,
                    PostalCode = "90550-030",
                    CityId = 21
                },
                new Manufacturer
                {
                    Id = 19,
                    ShortName = "Pearl Drums",
                    FullName = "Pearl Musical Instrument Company",
                    CNPJ = "40.430.233/0001-49",
                    Phone = "(31) 2508-8220",
                    Email = "contato@pearl-drums.com.br",
                    Address = "Rua João Camilo de Oliveira Torres, 405 - Mangabeiras - Belo Horizonte-MG",
                    Complement = null,
                    Number = 405,
                    PostalCode = "30210-260",
                    CityId = 13
                },
                new Manufacturer
                {
                    Id = 20,
                    ShortName = "Mapex Drums",
                    FullName = "Mapex Drums",
                    CNPJ = "81.243.864/0001-36",
                    Phone = "(31) 2508-8220",
                    Email = "contato@mapex.com.br",
                    Address = "Rua André Bacci, 665 - Conjunto Residencial José Bonifácio - São Paulo-SP",
                    Complement = null,
                    Number = 665,
                    PostalCode = "08255-640",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 21,
                    ShortName = "Meteoro",
                    FullName = "Meteoro Amplifiers",
                    CNPJ = "38.086.573/0001-52",
                    Phone = "(11) 2549-5247",
                    Email = "contato@meteoro.com.br",
                    Address = "Rua José Martins dos Santos, 451 - Jardim Santa Terezinha (Zona Leste) - São Paulo-SP",
                    Complement = null,
                    Number = 451,
                    PostalCode = "08430-110",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 22,
                    ShortName = "Marshall",
                    FullName = "Marshall Amplification",
                    CNPJ = "05.880.512/0001-03",
                    Phone = "(11) 2700-8751",
                    Email = "contato@marshall.com.br",
                    Address = "Rua André Olindo Lednik, 118 - Vila Itaberaba - São Paulo-SP",
                    Complement = null,
                    Number = 118,
                    PostalCode = "02846-150",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 23,
                    ShortName = "Laney",
                    FullName = "Laney Amplification",
                    CNPJ = "37.854.918/0001-08",
                    Phone = "(41) 3844-8978",
                    Email = "contato@laney.com.br",
                    Address = "Rua Jornalista Octávio Secundino, 216 - Bom Retiro - Curitiba-PR",
                    Complement = null,
                    Number = 216,
                    PostalCode = "80520-480",
                    CityId = 16
                },
                new Manufacturer
                {
                    Id = 24,
                    ShortName = "Blackstar",
                    FullName = "Blackstar Amplification",
                    CNPJ = "55.889.615/0001-02",
                    Phone = "(41) 3885-3977",
                    Email = "contato@blackstar.com.br",
                    Address = "Rua Reinaldino Schaffenberg de Quadros, 955 - Cristo Rei - Curitiba-PR",
                    Complement = null,
                    Number = 955,
                    PostalCode = "80050-435",
                    CityId = 16
                },
                new Manufacturer
                {
                    Id = 25,
                    ShortName = "Orange",
                    FullName = "Orange Music Electronic Company",
                    CNPJ = "28.348.123/0001-37",
                    Phone = "(48) 3830-1131",
                    Email = "contato@orange.com.br",
                    Address = "Rua Ana Luiza Vieira, 344 - Campeche - Florianópolis-SC",
                    Complement = null,
                    Number = 344,
                    PostalCode = "88063-640",
                    CityId = 24
                },
                new Manufacturer
                {
                    Id = 26,
                    ShortName = "Soldano",
                    FullName = "Soldano Custom Amplification",
                    CNPJ = "43.954.877/0001-24",
                    Phone = "(71) 2760-7633",
                    Email = "contato@soldano.com.br",
                    Address = "Travessa Jacob de Carvalho, 309 - Águas Claras - Salvador-BA",
                    Complement = null,
                    Number = 309,
                    PostalCode = "41310-330",
                    CityId = 5
                },
                new Manufacturer
                {
                    Id = 27,
                    ShortName = "Peavey",
                    FullName = "Peavey Electronics Corporation",
                    CNPJ = "84.186.551/0001-81",
                    Phone = "(27) 3645-3626",
                    Email = "contato@peavey.com.br",
                    Address = "Rua Guilherne Meyer, 784 - Santa Tereza - Vitória-ES",
                    Complement = null,
                    Number = 784,
                    PostalCode = "29026-833",
                    CityId = 8
                },
                new Manufacturer
                {
                    Id = 28,
                    ShortName = "VOX",
                    FullName = "VOX Ltda.",
                    CNPJ = "18.205.127/0001-02",
                    Phone = "(11) 3679-0939",
                    Email = "contato@vox.com.br",
                    Address = "Rua Joselyr de Moura Bastos, 550 - City América - São Paulo-SP",
                    Complement = null,
                    Number = 550,
                    PostalCode = "05119-010",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 29,
                    ShortName = "Mesa Boogie",
                    FullName = "Mesa Engineering",
                    CNPJ = "83.139.460/0001-22",
                    Phone = "(11) 2901-8699",
                    Email = "contato@mesa-engineering.com.br",
                    Address = "Rua Antíoco, 253 - Imirim - São Paulo-SP",
                    Complement = null,
                    Number = 253,
                    PostalCode = "02540-090",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 30,
                    ShortName = "Hiwatt",
                    FullName = "Hiwatt Amplification",
                    CNPJ = "37.513.294/0001-65",
                    Phone = "(11) 2694-6412",
                    Email = "contato@hiwatt.com.br",
                    Address = "Estrada de Itapecerica, 158 - Parque Fernanda - São Paulo-SP",
                    Complement = null,
                    Number = 158,
                    PostalCode = "05858-002",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 31,
                    ShortName = "Boss",
                    FullName = "Boss Corporation",
                    CNPJ = "75.841.505/0001-88",
                    Phone = "(11) 2243-4357",
                    Email = "contato@boss.com.nr",
                    Address = "Travessa Manuel Corvalam, 962 - Vila Nova Cachoeirinha - São Paulo-SP",
                    Complement = null,
                    Number = 962,
                    PostalCode = "02613-055",
                    CityId = 25 
                },
                new Manufacturer
                {
                    Id = 32,
                    ShortName = "Electro-Harmonix",
                    FullName = "Electro-Harmonix",
                    CNPJ = "61.841.227/0001-54",
                    Phone = "(11) 2678-1061",
                    Email = "contato@electro-harmonix.com.br",
                    Address = "Travessa Ferdinando Pellegrini, 259 - Vila Serralheiro - São Paulo-SP",
                    Complement = null,
                    Number = 259,
                    PostalCode = "02835-100",
                    CityId = 25
                },
                new Manufacturer
                {
                    Id = 33,
                    ShortName = "Fuhrmann",
                    FullName = "Fuhrmann Efeitos Ltda.",
                    CNPJ = "78.156.071/0001-75",
                    Phone = "(11) 2636-7352",
                    Email = "contato@fuhrmann.com.br",
                    Address = "Rua Antônio Carlos, 130 - Consolação - São Paulo-SP",
                    Complement = null,
                    Number = 130,
                    PostalCode = "01309-905",
                    CityId = 25
                });
        }

        private void SeedProviders()
        {
            _context.Providers.AddOrUpdate(p => p.Id,
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
                },
                new Provider
                {
                    Id = 11,
                    ShortName = "Super Som",
                    FullName = "Super Som Instrumentos Musicais",
                    CNPJ = "41.054.411/0001-47",
                    Phone = "(44) 3226-8708",
                    Email = "contato@supersom.com.br",
                    Address = "Rua Joubert de Carvalho, 306 - Zona 01 - Maringá-PR",
                    Complement = null,
                    Number = 306,
                    PostalCode = "87013-200",
                    CityId = 28
                },
                new Provider
                {
                    Id = 12,
                    ShortName = "PlayMusic",
                    FullName = "PlayMusic Instrumentos Musicais",
                    CNPJ = "06.310.937/0001-40",
                    Phone = "(44) 3029-8636",
                    Email = "contato@playmusic.com.br",
                    Address = "Rua Joubert de Carvalho, 372 - Zona 01, Maringá-PR",
                    Complement = null,
                    Number = 372,
                    PostalCode = "87013-200",
                    CityId = 28
                },
                new Provider
                {
                    Id = 13,
                    ShortName = "Drum Shop",
                    FullName = "Drum Shop",
                    CNPJ = "58.868.176/0001-40",
                    Phone = "(41) 3324-8000",
                    Email = "contato@drumshop.com.br",
                    Address = "Rua Desembargador Westphalen, 486 - Centro - Curitiba-PR",
                    Complement = null,
                    Number = 486,
                    PostalCode = "80010-110",
                    CityId = 16
                },
                new Provider
                {
                    Id = 14,
                    ShortName = "Plander Instrumentos Musicais",
                    FullName = "Plander Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "51.305.797/0001-76",
                    Phone = "(41) 3323-3636",
                    Email = "contato@plander.com.br",
                    Address = "Rua Alferes Poli, 620 - Centro - Curitiba-PR",
                    Complement = null,
                    Number = 620,
                    PostalCode = "80230-090",
                    CityId = 16
                },
                new Provider
                {
                    Id = 15,
                    ShortName = "Audiofex Musical Instruments",
                    FullName = "Audiofex Instrumentos Musicais, Ltda.",
                    CNPJ = "85.204.564/0001-07",
                    Phone = "(41) 3224-0925",
                    Email = "contato@udiofex.com.br",
                    Address = "Rua Desembargador Westphalen, 426 - Centro - Curitiba-PR",
                    Complement = null,
                    Number = 426,
                    PostalCode = "80010-110",
                    CityId = 17
                },
                new Provider
                {
                    Id = 16,
                    ShortName = "X5 Instrumentos Musicais",
                    FullName = "X5 Instrumentos Musicais, Ltda. Epp",
                    CNPJ = "24.491.731/0001-45",
                    Phone = "(11) 3060-6100",
                    Email = "contato@x5-instrumentos.com.nr",
                    Address = "Rua Teodoro Sampaio, 825 - Jardim Paulista - São Paulo-SP",
                    Complement = null,
                    Number = 825,
                    PostalCode = "05405-050",
                    CityId = 25
                },
                new Provider
                {
                    Id = 17,
                    ShortName = "Gang Music",
                    FullName = "Gang Music Instrumentos Musicais, Ltda.",
                    CNPJ = "42.326.238/0001-51",
                    Phone = "(11) 3061-5000",
                    Email = "contato@gang-music.com.br",
                    Address = "Rua dos Três Irmãos, 201 - Vila Progredior - São Paulo-SP",
                    Complement = null,
                    Number = 201,
                    PostalCode = "05615-190",
                    CityId = 25
                },
                new Provider
                {
                    Id = 18,
                    ShortName = "Intermezzo & Spina Instrumentos Musicais",
                    FullName = "Intermezzo & Spina, Ltda.",
                    CNPJ = "74.820.152/0001-77",
                    Phone = "(11) 3078-3200",
                    Email = "contato@intermezzoespina.com.br",
                    Address = "Avenida Cidade Jardim, 957 - Jardim Paulistano - São Paulo-SP",
                    Complement = null,
                    Number = 957,
                    PostalCode = "01453-000",
                    CityId = 25
                },
                new Provider
                {
                    Id = 19,
                    ShortName = "Copetti Guitars",
                    FullName = "Copetti Guitars, Ltda.",
                    CNPJ = "21.835.448/0001-03",
                    Phone = "(48) 3241-6165",
                    Email = "contato@copetti-guitars.com.br",
                    Address = "Avenida Josué di Bernardi, 443 - Campinas, Florianópolis-SC",
                    Complement = null,
                    Number = 443,
                    PostalCode = "88101-200",
                    CityId = 24
                },
                new Provider
                {
                    Id = 20,
                    ShortName = "Zandomênico",
                    FullName = "Zandomênico Instrumentos Musicais, Ltda.",
                    CNPJ = "24.453.937/0001-80",
                    Phone = "(48) 3222-4509",
                    Email = "contato@zandomenico.com.br",
                    Address = "Rua Conselheiro Mafra, 372 - Centro - Florianópolis-SC",
                    Complement = null,
                    Number = 372,
                    PostalCode = "88010-101",
                    CityId = 24
                },
                new Provider
                {
                    Id = 21,
                    ShortName = "Caballero Music",
                    FullName = "Caballero Music Atacado e Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "70.376.555/0001-18",
                    Phone = "(51) 3022-5252",
                    Email = "contato@caballeromusic.com.br",
                    Address = "Rua Hoffmann, 226 - Floresta - Porto Alegre-RS",
                    Complement = null,
                    Number = 226,
                    PostalCode = "90220-170",
                    CityId = 21
                },
                new Provider
                {
                    Id = 22,
                    ShortName = "Porão Musical",
                    FullName = "Porão Musical Instrumentos Musicais, Ltda.",
                    CNPJ = "67.748.544/0001-07",
                    Phone = "(51) 3022-3100",
                    Email = "contato@poraomusical.com.br",
                    Address = "Rua Coronel Vicente, 442 - Centro Histórico - Porto Alegre-RS",
                    Complement = null,
                    Number = 442,
                    PostalCode = "90030-040",
                    CityId = 21
                },
                new Provider
                {
                    Id = 23,
                    ShortName = "Guitar Garage",
                    FullName = "Guitar Garage Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "71.441.957/0001-11",
                    Phone = "(51) 3331-3234",
                    Email = "contato@guitar-garage.com.br",
                    Address = "Rua Miguel Tostes, 870 - Rio Branco - Porto Alegre-RS",
                    Complement = null,
                    Number = 870,
                    PostalCode = "90430-061",
                    CityId = 21
                },
                new Provider
                {
                    Id = 24,
                    ShortName = "Made in Brazil Music Store",
                    FullName = "Made in Brazil Music Store, Ltda.",
                    CNPJ = "93.702.785/0001-25",
                    Phone = "(61) 3462-1066",
                    Email = "contato@madeinbrasilmusicstore.com.br",
                    Address = "Avenida Antônio Nascimento, 421 - Guará - Brasília-DF",
                    Complement = null,
                    Number = 421,
                    PostalCode = "71219-900",
                    CityId = 7
                },
                new Provider
                {
                    Id = 25,
                    ShortName = "Music Master",
                    FullName = "Music Master Distribuidora, Ltda.",
                    CNPJ = "72.258.535/0001-78",
                    Phone = "(61) 3992-2575",
                    Email = "contato@musicmaster-brasilia.com.br",
                    Address = "Rua Quito, 566 - Asa Norte - Brasília-DF",
                    Complement = null,
                    Number = 566,
                    PostalCode = "70760-511",
                    CityId = 7
                },
                new Provider
                {
                    Id = 26,
                    ShortName = "Protec Instrumentos Musicais",
                    FullName = "Protec Distribuidora de Instrumentos Musicais",
                    CNPJ = "33.714.631/0001-21",
                    Phone = "(61) 3964-2626",
                    Email = "contato@protec-instrumentos.com.br",
                    Address = "Avenida Liberdade, 1378 - Santa Felicidade - Brasília-DF",
                    Complement = null,
                    Number = 1378,
                    PostalCode = "70782-122",
                    CityId = 7
                },
                new Provider
                {
                    Id = 27,
                    ShortName = "VAM - Vitória Áudio e Música",
                    FullName = "VAM Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "04.411.369/0001-48",
                    Phone = "(27) 3235-8400",
                    Email = "contato@vam.com.br",
                    Address = "Avenida Nossa Sra. da Penha, 2462 - Santa Luíza - Vitória-ES",
                    Complement = null,
                    Number = 2462,
                    PostalCode = "29045-402",
                    CityId = 8
                },
                new Provider
                {
                    Id = 28,
                    ShortName = "Backstage Instrumentos",
                    FullName = "Backstage Instrumentos, Ltda.",
                    CNPJ = "85.618.673/0001-62",
                    Phone = "(27) 3225-3648",
                    Email = "contato@backstage-instrumentos.com.br",
                    Address = "Avenida Rio Branco, 799 - Santa Lúcia - Vitória-ES",
                    Complement = null,
                    Number = 799,
                    PostalCode = "29056-253",
                    CityId = 8
                },
                new Provider
                {
                    Id = 29,
                    ShortName = "Carneiro Instrumentos Musicais",
                    FullName = "Carneiro Instrumentos Musicais, Ltda.",
                    CNPJ = "85.751.613/0001-13",
                    Phone = "(27) 3239-4626",
                    Email = "contato@carneiro-instrumentos.com.br",
                    Address = "Avenida Jerônimo Monteiro, 1310 - Vila Velha - Vitória-ES",
                    Complement = null,
                    Number = 1310,
                    PostalCode = "29123-012",
                    CityId = 8
                },
                new Provider
                {
                    Id = 30,
                    ShortName = "Musicland",
                    FullName = "Musicland Distribuidora de Instrumentos Musicais, Ltda.",
                    CNPJ = "60.071.822/0001-95",
                    Phone = "(44) 3251-2749",
                    Email = "contato@musicland-maringa.com.br",
                    Address = "Avenida Londrina, 7891 - Jardim Aeroporto - Maringá-PR",
                    Complement = null,
                    Number = 7891,
                    PostalCode = "87053-420",
                    CityId = 28
                });
        }

        private void SeedProducts()
        {
            _context.Products.AddOrUpdate(p => p.Id,
                new Product
                {
                    Id = 1,
                    Description = "Guitarra Fender Stratocaster Stardard - Artic White",
                    PurchasePrice = 1788.00,
                    SalePrice = 5364.00,
                    Stock = 3,
                    Weight = 3.6,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 2,
                    Description = "Guitarra Gibson Les Paul Traditional - Honery Burst",
                    PurchasePrice = 2967.00,
                    SalePrice = 8901.00,
                    Stock = 5,
                    Weight = 4.2,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    ProviderId = 2,
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
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
                    UnitId = 48
                },
                new Product
                {
                    Id = 11,
                    Description = "Guitarra Fender Mustang '62 Reissue - Offset Olive Green",
                    PurchasePrice = 1799.7,
                    SalePrice = 5399.10,
                    Stock = 2,
                    Weight = 3.4,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 12,
                    Description = "Amplificador Blackstar S1-104 EL 34/6L6",
                    PurchasePrice = 1653.30,
                    SalePrice = 4960.00,
                    Stock = 4,
                    Weight = 19.300,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 24,
                    ProviderId = 3,
                    UnitId = 48
                },
                new Product
                {
                    Id = 13,
                    Description = "Amplificador Orange AD30TC - 2x12 30W",
                    PurchasePrice = 4361.99,
                    SalePrice = 13085.99,
                    Stock = 1,
                    Weight = 17.280,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 25,
                    ProviderId = 10,
                    UnitId = 48
                },
                new Product
                {
                    Id = 14,
                    Description = "Amplificador Orange Dark Terror - 15W",
                    PurchasePrice = 3200.00,
                    SalePrice = 5537.99,
                    Stock = 3,
                    Weight = 5.160,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 25,
                    ProviderId = 10,
                    UnitId = 48
                },
                new Product
                {
                    Id = 15,
                    Description = "Amplificador Soldano 100w Super Lead Overdrive (SLO-100)",
                    PurchasePrice = 8699.00,
                    SalePrice = 12780.99,
                    Stock = 1,
                    Weight = 15.800,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 26,
                    ProviderId = 4,
                    UnitId = 48
                },
                new Product
                {
                    Id = 16,
                    Description = "Amplificador Fender Hot Deluxe III - 1x12 40W",
                    PurchasePrice = 6420.00,
                    SalePrice = 10734.99,
                    Stock = 3,
                    Weight = 20.41,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 1,
                    ProviderId = 1,
                    UnitId = 48
                },
                new Product
                {
                    Id = 17,
                    Description = "Amplificador Peavey 6505 - 120W",
                    PurchasePrice = 5230.90,
                    SalePrice = 7799.99,
                    Stock = 4,
                    Weight = 8.200,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 27,
                    ProviderId = 8,
                    UnitId = 48
                },
                new Product
                {
                    Id = 18,
                    Description = "Amplificador Vox AC30C2 - 2x12 30W",
                    PurchasePrice = 7392.99,
                    SalePrice = 10999.89,
                    Stock = 6,
                    Weight = 16.320,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 28,
                    ProviderId = 7,
                    UnitId = 48
                },
                new Product
                {
                    Id = 19,
                    Description = "Amplificador Marshall JVM400 - 110W",
                    PurchasePrice = 8500.00,
                    SalePrice = 11690.90,
                    Stock = 1,
                    Weight = 22.000,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 22,
                    ProviderId = 1,
                    UnitId = 48
                },
                new Product
                {
                    Id = 20,
                    Description = "Amplificador Mesa Boogie Dual Rectifier - 100W",
                    PurchasePrice = 5700.90,
                    SalePrice = 7800.00,
                    Stock = 1,
                    Weight = 15.285,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 29,
                    ProviderId = 1,
                    UnitId = 48
                },
                new Product
                {
                    Id = 21,
                    Description = "Amplificador Hiwatt G50CM - 1x12 50W",
                    PurchasePrice = 1459.00,
                    SalePrice = 1860.00,
                    Stock = 12,
                    Weight = 8.120,
                    Expiration = null,
                    CategoryId = 8,
                    ManufacturerId = 30,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 22,
                    Description = "Pedal Distorção Boss Metal Zone MT-2",
                    PurchasePrice = 300.00,
                    SalePrice = 459.00,
                    Stock = 12,
                    Weight = 0.400,
                    Expiration = null,
                    CategoryId = 9,
                    ManufacturerId = 31,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 23,
                    Description = "Pedal Fuzz Electro-Harmonix Big Muff Pi",
                    PurchasePrice = 500.90,
                    SalePrice = 709.10,
                    Stock = 7,
                    Weight = 0.650,
                    Expiration = null,
                    CategoryId = 9,
                    ManufacturerId = 32,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 24,
                    Description = "Pedal Delay Fuhrmann Analog Echo AE01",
                    PurchasePrice = 159.90,
                    SalePrice = 263.42,
                    Stock = 12,
                    Weight = 0.450,
                    Expiration = null,
                    CategoryId = 9,
                    ManufacturerId = 33,
                    ProviderId = 2,
                    UnitId = 48
                },
                new Product
                {
                    Id = 25,
                    Description = "Guitarra SX Stratocaster SST62 - Preta",
                    PurchasePrice = 500.90,
                    SalePrice = 828.00,
                    Stock = 10,
                    Weight = 3.600,
                    Expiration = null,
                    CategoryId = 1,
                    ManufacturerId = 11,
                    ProviderId = 2,
                    UnitId = 48
                });
        }

        private void SeedUsers()
        {
            _context.Users.AddOrUpdate(u => u.Id,
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
                    Email = "pedro@gmail.com",
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
                    Email = "laura.farias@gmail.com",
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
