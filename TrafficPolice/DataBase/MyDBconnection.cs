using System.Data.Entity;

namespace TrafficPolice
{
    public class MyDBconnection : DbContext
    {
        // Контекст настроен для использования строки подключения "MyDBconnection" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TrafficPolice.MyDBconnection" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MyDBconnection" 
        // в файле конфигурации приложения.
        public MyDBconnection()
            : base("name=MyDBconnection")
        {
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriversLicense> DriversLicenses { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Sertification> Sertifications { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Ptc> Ptcs { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Ctc> Ctcs { get; set; }
        public virtual DbSet<Statement> Statements { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<DriverKategoryLicence> DriverKategoryLicences { get; set; }
        public virtual DbSet<Raports> Raports { get; set; }
        public virtual DbSet<Dtp> Dtps { get; set; }
        public virtual DbSet<DtpCar> DtpCars { get; set; }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}