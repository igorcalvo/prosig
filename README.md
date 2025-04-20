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
## Instructions

### Prerequisites

- [Git](https://git-scm.com/downloads)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQLite](https://www.sqlite.org/download.html) (optional, since the file `.db` will be generated automatically)

### Running it

1. Clone the repo:
```bash
git clone https://github.com/igorcalvo/prosig.git
cd prosig
```
2. Restore and build:
```bash
dotnet restore
dotnet build
```

3. Run Migrations
```bash
cd Blog.API
dotnet ef database update
```

4. Run it with `dotnet run --project Blog.API.csproj`

5. Go to [https://localhost:7010/swagger/index.html](https://localhost:7010/swagger/index.html])

### Endpoints

#### CreatePost
 - Don't send an post.Id or post.comments.id
 
 Example:
 
 ```json
 {
  "title": "some new post",
  "content": "with a lot of content",
  "comments": [
    {
      "text": "comment1",
    },
    {
      "text": "comment2"
    }
  ]
}
 ```
 
#### CreateComment
- Don't send comment.Id

Example:

 ```json
postId and the body as:

{
  "text": "a new comment has been added"
}
 ```

## TODOs

- More unit tests
- Add more functionality to CommentService (edit, delete...)
- Expand on the DTOs
- Add logging
- Add authentication to the API