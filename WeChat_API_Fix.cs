using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Method 1: Basic fix with proper headers
        await UploadVoiceFileBasic();
        
        // Method 2: More robust implementation with error handling
        await UploadVoiceFileRobust();
    }
    
    static async Task UploadVoiceFileBasic()
    {
        try
        {
            using var client = new HttpClient();
            
            // Set User-Agent header (WeChat API often requires this)
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
            
            var request = new HttpRequestMessage(HttpMethod.Post, 
                "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=dFf2D7t6tZawJmMLNJVA424PJq3b2i0oCjRkgajSm0RXo65Or0RZb4J3-p-j3nkxmAh7S_6XrjAQXTloyYi22VoKKKzyAeJbNP7TTT-T6oPgdB8C_W0WPZvBGIAq4KWbIE7P49KF6F5cKR347j00gCq3Uepkv9n6wmMCQbhuYC5qrzA3Dq6MNxzHQN5dWEyE4akrJBK00LP3hL-d03NsXw&type=voice");
            
            var content = new MultipartFormDataContent();
            
            // Important: Use FileStream instead of File.OpenRead for better control
            var filePath = "/M:/ttsmaker-file-2025-7-29-15-16-22.amr";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamContent = new StreamContent(fileStream);
            
            // Set proper content type for AMR files
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/amr");
            
            // Use just the filename, not the full path
            var fileName = Path.GetFileName(filePath);
            content.Add(streamContent, "media", fileName);
            
            request.Content = content;
            
            var response = await client.SendAsync(request);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Success: " + responseContent);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}: {errorContent}");
            }
            
            fileStream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
    
    static async Task UploadVoiceFileRobust()
    {
        var filePath = "/M:/ttsmaker-file-2025-7-29-15-16-22.amr";
        var accessToken = "dFf2D7t6tZawJmMLNJVA424PJq3b2i0oCjRkgajSm0RXo65Or0RZb4J3-p-j3nkxmAh7S_6XrjAQXTloyYi22VoKKKzyAeJbNP7TTT-T6oPgdB8C_W0WPZvBGIAq4KWbIE7P49KF6F5cKR347j00gCq3Uepkv9n6wmMCQbhuYC5qrzA3Dq6MNxzHQN5dWEyE4akrJBK00LP3hL-d03NsXw";
        
        try
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }
            
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10); // Increase timeout for large files
            
            // Set headers that Postman typically sends
            client.DefaultRequestHeaders.Add("User-Agent", 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={accessToken}&type=voice";
            
            using var content = new MultipartFormDataContent();
            
            // Read file content
            var fileBytes = await File.ReadAllBytesAsync(filePath);
            var byteArrayContent = new ByteArrayContent(fileBytes);
            
            // Set content type for AMR files
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/amr");
            
            // Add file with proper name
            var fileName = Path.GetFileName(filePath);
            content.Add(byteArrayContent, "media", fileName);
            
            // Log request details for debugging
            Console.WriteLine($"Uploading file: {fileName}");
            Console.WriteLine($"File size: {fileBytes.Length} bytes");
            Console.WriteLine($"URL: {url}");
            
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, url) { Content = content });
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Upload successful!");
                Console.WriteLine($"Response: {responseContent}");
            }
            else
            {
                Console.WriteLine($"Upload failed with status: {response.StatusCode}");
                Console.WriteLine($"Response: {responseContent}");
                
                // Log response headers for debugging
                Console.WriteLine("Response Headers:");
                foreach (var header in response.Headers)
                {
                    Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
                }
            }
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"HTTP Request Exception: {httpEx.Message}");
        }
        catch (TaskCanceledException tcEx)
        {
            Console.WriteLine($"Request Timeout: {tcEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Exception: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}

// Alternative approach using RestSharp (if you prefer)
/*
using RestSharp;

static async Task UploadWithRestSharp()
{
    var client = new RestClient("https://qyapi.weixin.qq.com");
    var request = new RestRequest("/cgi-bin/media/upload", Method.Post);
    
    request.AddParameter("access_token", "your_access_token");
    request.AddParameter("type", "voice");
    request.AddFile("media", "/M:/ttsmaker-file-2025-7-29-15-16-22.amr");
    
    var response = await client.ExecuteAsync(request);
    Console.WriteLine(response.Content);
}
*/