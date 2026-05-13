using System;
using System.Collections.Generic;
using curs.ModelsDB_DTO;
using Microsoft.EntityFrameworkCore;

namespace curs.ModelsDB;

public partial class KindergartenMenuContext : DbContext
{
    public KindergartenMenuContext()
    {
    }

    public KindergartenMenuContext(DbContextOptions<KindergartenMenuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishCategoriesDict> DishCategoriesDicts { get; set; }

    public virtual DbSet<DishIngredient> DishIngredients { get; set; }

    public virtual DbSet<MealTypeDict> MealTypeDicts { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<RecipeComm> RecipeComms { get; set; }

    public virtual DbSet<VCategoryPopularity> VCategoryPopularities { get; set; }

    public virtual DbSet<VCategoryRotationCompliance> VCategoryRotationCompliances { get; set; }

    public virtual DbSet<VDailyMenuSummary> VDailyMenuSummaries { get; set; }

    public virtual DbSet<VFindUnusedDish> VFindUnusedDishes { get; set; }

    public virtual DbSet<VOrphanedIngredient> VOrphanedIngredients { get; set; }

    public virtual DbSet<VwDishServingDate> VwDishServingDates { get; set; }

    public virtual DbSet<FnCheckMenuCompleteness> FnCheckMenuCompletenesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=KindergartenMenu; User=исп-31; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity.Property(e => e.DishId)
                .ValueGeneratedNever()
                .HasColumnName("dish_ID");
            entity.Property(e => e.CategoryId).HasColumnName("category_ID");
            entity.Property(e => e.DishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dish_name");
            entity.Property(e => e.Recipe)
                .HasColumnType("text")
                .HasColumnName("recipe");

            entity.HasOne(d => d.Category).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dishes_DishCategories_Dict");
        });

        modelBuilder.Entity<DishCategoriesDict>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("DishCategories_Dict");

            entity.HasIndex(e => e.CategoryId, "UK_DishCategories_Dict").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<DishIngredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId);

            entity.ToTable("DishIngredient");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_ID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Unit).HasColumnName("unit");
        });

        modelBuilder.Entity<MealTypeDict>(entity =>
        {
            entity.HasKey(e => e.MealTypeId);

            entity.ToTable("MealType_Dict");

            entity.HasIndex(e => e.MealTypeId, "UX_MealType_Dict").IsUnique();

            entity.Property(e => e.MealTypeId).HasColumnName("meal_type_ID");
            entity.Property(e => e.ServingOrder).HasColumnName("serving_order");
            entity.Property(e => e.TypeName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu", tb => tb.HasTrigger("trg_Menu_SetNextDayIfNull"));

            entity.Property(e => e.MenuId).HasColumnName("menu_ID");
            entity.Property(e => e.DishId).HasColumnName("dish_ID");
            entity.Property(e => e.MealTypeId).HasColumnName("meal_type_ID");
            entity.Property(e => e.MenuDate).HasColumnName("menu_date");

            entity.HasOne(d => d.Dish).WithMany(p => p.Menus)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Dishes");

            entity.HasOne(d => d.MealType).WithMany(p => p.Menus)
                .HasForeignKey(d => d.MealTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_MealType_Dict");
        });

        modelBuilder.Entity<RecipeComm>(entity =>
        {
            entity.HasKey(e => e.RecipeId);

            entity.ToTable("Recipe_Comm");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_ID");
            entity.Property(e => e.DishId).HasColumnName("dish_ID");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_ID");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Dish).WithMany(p => p.RecipeComms)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_Comm_Dishes");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeComms)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_Comm_DishIngredient");
        });

        modelBuilder.Entity<VCategoryPopularity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_CategoryPopularity");

            entity.Property(e => e.Категория)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.КоличествоПодач).HasColumnName("Количество_подач");
        });

        modelBuilder.Entity<VCategoryRotationCompliance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_CategoryRotationCompliance");

            entity.Property(e => e.ВсегоПодач).HasColumnName("Всего_подач");
            entity.Property(e => e.Категория)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.МаксИнтервалДней).HasColumnName("Макс_интервал_дней");
            entity.Property(e => e.МинИнтервалДней).HasColumnName("Мин_интервал_дней");
            entity.Property(e => e.СреднийИнтервалДней)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Средний_интервал_дней");
        });

        modelBuilder.Entity<VDailyMenuSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_DailyMenuSummary");

            entity.Property(e => e.Завтрак)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Обед)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Полдник)
                .HasMaxLength(8000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VFindUnusedDish>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_FindUnusedDishes");

            entity.Property(e => e.DishId).HasColumnName("dish_ID");
            entity.Property(e => e.Категория)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.НазваниеБлюда)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Название_блюда");
        });

        modelBuilder.Entity<VOrphanedIngredient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_OrphanedIngredients");

            entity.Property(e => e.IngredientId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ingredient_ID");
            entity.Property(e => e.ЕдИзмерения).HasColumnName("Ед_измерения");
            entity.Property(e => e.Примечание)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Продукт)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwDishServingDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DishServingDates");

            entity.Property(e => e.DishId).HasColumnName("dish_ID");
            entity.Property(e => e.DishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dish_name");
            entity.Property(e => e.MenuDate).HasColumnName("menu_date");
        });

        OnModelCreatingPartial(modelBuilder);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FnCheckMenuCompleteness>().HasNoKey();
        modelBuilder.HasDbFunction(typeof(KindergartenMenuContext).GetMethod(nameof(GetCheckMenuCompleteness), new[] { typeof(DateOnly) })).HasName("fn_CheckMenuCompleteness").HasSchema("dbo");
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public IQueryable<FnCheckMenuCompleteness> GetCheckMenuCompleteness(DateOnly checkDate) => FromExpression(() => GetCheckMenuCompleteness(checkDate));
}
