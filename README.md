# Blog

## Migrations
```bash
Blog\Blog.API>

# Add 
dotnet ef migrations add InitialCreate --project ../Blog.Infrastructure --startup-project . --output-dir ../Blog.Infrastructure/Migrations

# Remove
dotnet ef migrations remove --project ../Blog.Infrastructure --startup-project .

# Update
dotnet ef database update

# Revert
dotnet ef database update InitialCreate
```
