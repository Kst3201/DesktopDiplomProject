using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesktopDiplomProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class NinethWithQuantileMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION public.get_quantile(
                    table_name text,
                    column_name text,
                    percentile double precision
                )
                RETURNS TABLE(result double precision)
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    RETURN QUERY EXECUTE format(
                        'SELECT 
                             percentile_cont(%s) WITHIN GROUP (ORDER BY %I) AS result
                         FROM %I',
                        percentile, column_name,
                        table_name
                    );
                END;
                $$;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS public.get_quantile(text, text, double precision);");
        }
    }
}
