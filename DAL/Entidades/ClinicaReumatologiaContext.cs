using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Final_CentroMedico;

public partial class ClinicaReumatologiaContext : DbContext
{
    public ClinicaReumatologiaContext()
    {
    }

    public ClinicaReumatologiaContext(DbContextOptions<ClinicaReumatologiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Ocupacion> Ocupacions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=MSI;Database=CLINICA_REUMATOLOGIA;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentes).HasName("PK__ANTECEDE__26F55BAF55D40FEB");

            entity.ToTable("ANTECEDENTES");

            entity.Property(e => e.IdAntecedentes).HasColumnName("ID_ANTECEDENTES");
            entity.Property(e => e.Ago)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AGO");
            entity.Property(e => e.Ahf)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AHF");
            entity.Property(e => e.ApnoP)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("APnoP");
            entity.Property(e => e.App)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("APP");
            entity.Property(e => e.Aqtx)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AQTx");
        });

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__BITACORA__44E70BF34D39BF8D");

            entity.ToTable("BITACORA");

            entity.Property(e => e.IdBitacora).HasColumnName("ID_BITACORA");
            entity.Property(e => e.CambiosTratamiento)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("CAMBIOS_TRATAMIENTO");
            entity.Property(e => e.Evolucion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EVOLUCION");
            entity.Property(e => e.IdExpediente).HasColumnName("ID_EXPEDIENTE");
            entity.Property(e => e.Sintomatologia)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("SINTOMATOLOGIA");

            entity.HasOne(d => d.IdExpedienteNavigation).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.IdExpediente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BITACORA_EXPEDIENTE");
        });

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.IdCanton).HasName("PK__CANTON__69745474A0496A19");

            entity.ToTable("CANTON");

            entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROVINCIA");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK_CANTON_PROVINCIA");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__CITA__6416F2F049B7B974");

            entity.ToTable("CITA");

            entity.Property(e => e.IdCita).HasColumnName("ID_CITA");
            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.Hora).HasColumnName("HORA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MOTIVO");

            entity.HasOne(d => d.CedulaPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.CedulaPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CITA_PACIENTE");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CITA_USUARIO");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__DIRECCIO__FC7E9E8EC883B9E1");

            entity.ToTable("DIRECCION");

            entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");
            entity.Property(e => e.Direccion1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");
            entity.Property(e => e.IdDistrito).HasColumnName("ID_DISTRITO");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DIRECCION_CANTON");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DIRECCION_DISTRITO");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DIRECCION_PROVINCIA");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistrito).HasName("PK__DISTRITO__6F133D49E8C1EF84");

            entity.ToTable("DISTRITO");

            entity.Property(e => e.IdDistrito).HasColumnName("ID_DISTRITO");
            entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");
            entity.Property(e => e.NombreDistrito)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DISTRITO");

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdCanton)
                .HasConstraintName("FK_DISTRITO_CANTON");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.IdExpediente).HasName("PK__EXPEDIEN__A99BAD8E3E425699");

            entity.ToTable("EXPEDIENTE");

            entity.Property(e => e.IdExpediente).HasColumnName("ID_EXPEDIENTE");
            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.ExamenFisico)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EXAMEN_FISICO");
            entity.Property(e => e.IdAntecedentes).HasColumnName("ID_ANTECEDENTES");
            entity.Property(e => e.ImpresionDiagnostica)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("IMPRESION_DIAGNOSTICA");
            entity.Property(e => e.PadecimientoActual)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PADECIMIENTO_ACTUAL");
            entity.Property(e => e.PlanTratamiento)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PLAN_TRATAMIENTO");

            entity.HasOne(d => d.CedulaPacienteNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.CedulaPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EXPEDIENTE_PACIENTE");

            entity.HasOne(d => d.IdAntecedentesNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdAntecedentes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EXPEDIENTE_ANTECEDENTES");
        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(e => e.IdOcupacion).HasName("PK__OCUPACIO__0325EA4C8F33985C");

            entity.ToTable("OCUPACION");

            entity.Property(e => e.IdOcupacion).HasColumnName("ID_OCUPACION");
            entity.Property(e => e.Ocupacion1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OCUPACION");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.CedulaPaciente).HasName("PK__PACIENTE__FD8C4C6D08667E77");

            entity.ToTable("PACIENTE");

            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");
            entity.Property(e => e.IdOcupacion).HasColumnName("ID_OCUPACION");
            entity.Property(e => e.IdSexo).HasColumnName("ID_SEXO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_DIRECCION");

            entity.HasOne(d => d.IdOcupacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdOcupacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_OCUPACION");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_SEXO");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__PROVINCI__4245DC52EC49CE9A");

            entity.ToTable("PROVINCIA");

            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROVINCIA");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__203B0F6802030733");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ROL");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo).HasName("PK__SEXO__F5FF4DDC2A2E79C8");

            entity.ToTable("SEXO");

            entity.Property(e => e.IdSexo).HasColumnName("ID_SEXO");
            entity.Property(e => e.Sexo1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SEXO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B90E5E638AE");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USUARIO_ROL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public void crearExpediente(
        string cedulaPaciente,
        int idAntecedentes, 
        string padecimientoActual, 
        string examenFisico, 
        string impresionDiagnostica,
        string planTratamiento) {

        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_EXPEDIENTE {0},{1},{2},{3},{4}, {5}",
            cedulaPaciente,
            idAntecedentes,
            padecimientoActual,
            examenFisico,
            impresionDiagnostica,
            planTratamiento
        );
    
    }


    public void crearAntecedentes(
        string AGO,
        string APnoP,
        string APP,
        string AHF,
        string AQTx 
        ) {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_ANTECEDENTES {0}, {1}, {2}, {3}, {4}",
            AGO,
            APnoP,
            APP,
            AHF,
            AQTx
        );
    }


    public void crearPaciente(
      string cedulaPaciente,
      string nombre,
      string primerApellido,
      string segundoApellido,
      int edad,
      int idSexo,
      int idOcupacion,
      int idDireccion,
      DateOnly fechaNacimiento
    ) {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_PACIENTE {0},{1},{2},{3},{4},{5},{6},{7}",
            cedulaPaciente,
            nombre,
            primerApellido,
            segundoApellido,
            edad,
            idSexo,
            idOcupacion,
            idDireccion,
            fechaNacimiento
        );
    
    }


    public void crearDireccion(
        int idProvincia,
        int idCanton,
        int idDistrito,
        string direccion
    ) {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_DIRECCION {0},{1}, {2}, {3}",
            idProvincia,
            idCanton,
            idDistrito,
            direccion
        );

    
    }

    public List<Ocupacion> obtenerOcupaciones() {

        return Ocupacions.FromSqlRaw("exec SP_LISTAR_OCUPACION").ToList();
    }

    public List<Sexo> obtenerSexos()
    {

        return Sexos.FromSqlRaw("exec SP_LISTAR_SEXO").ToList();
    }

    public List<Provincium> obtenerProvincia()
    {

        return Provincia.FromSqlRaw("exec SP_LISTAR_PROVINCIA").ToList();
    }

    public List<Canton> obtenerCanton()
    {

        return Cantons.FromSqlRaw("exec SP_LISTAR_CANTON").ToList();
    }

    public List<Distrito> obtenerDistrito()
    {

        return Distritos.FromSqlRaw("exec SP_LISTAR_DISTRITO").ToList();
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
