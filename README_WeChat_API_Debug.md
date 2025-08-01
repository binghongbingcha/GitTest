# WeChat API Upload Debug Guide

## Common Issues and Solutions

### 1. **Missing Headers**
Postman automatically adds headers that your code might be missing:

```csharp
client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
client.DefaultRequestHeaders.Add("Accept", "*/*");
```

### 2. **File Path Issues**
- Use only the filename in the multipart form, not the full path
- Ensure the file exists and is accessible

```csharp
var fileName = Path.GetFileName(filePath);
content.Add(streamContent, "media", fileName);
```

### 3. **Content-Type Headers**
Set proper content type for AMR files:

```csharp
streamContent.Headers.ContentType = new MediaTypeHeaderValue("audio/amr");
```

### 4. **Resource Management**
Properly dispose of streams and HttpClient:

```csharp
using var client = new HttpClient();
using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
```

## Debugging Steps

### Step 1: Compare Headers
Use Fiddler or similar tool to compare headers between Postman and your application.

### Step 2: Check File Access
```csharp
if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}
```

### Step 3: Log Request Details
```csharp
Console.WriteLine($"File size: {fileBytes.Length} bytes");
Console.WriteLine($"Content-Type: {streamContent.Headers.ContentType}");
```

### Step 4: Handle Specific Error Codes
```csharp
if (!response.IsSuccessStatusCode)
{
    var errorContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"Error {response.StatusCode}: {errorContent}");
}
```

## Common WeChat API Error Codes

- **40001**: Invalid access_token
- **40003**: Invalid media file
- **40004**: Invalid media type
- **40007**: Invalid media file ID
- **45001**: Media file size exceeds limit
- **45002**: Message content too long
- **45009**: Interface call exceeds limit

## Quick Fixes to Try

1. **Add User-Agent header** (most common fix)
2. **Use filename only, not full path**
3. **Set proper Content-Type for AMR files**
4. **Increase HttpClient timeout**
5. **Use ByteArrayContent instead of StreamContent**
6. **Check file permissions and existence**
7. **Verify access token is still valid**

## Alternative Using RestSharp

If HttpClient continues to fail, try RestSharp:

```bash
dotnet add package RestSharp
```

```csharp
var client = new RestClient("https://qyapi.weixin.qq.com");
var request = new RestRequest("/cgi-bin/media/upload", Method.Post);
request.AddParameter("access_token", accessToken);
request.AddParameter("type", "voice");
request.AddFile("media", filePath);
var response = await client.ExecuteAsync(request);
```