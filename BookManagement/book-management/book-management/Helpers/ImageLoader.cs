using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace book_management.Helpers
{
    public static class ImageLoader
    {
        public static readonly HttpClient ImageHttpClient;

        static ImageLoader()
        {
            ImageHttpClient = new HttpClient();
            ImageHttpClient.Timeout = TimeSpan.FromSeconds(8);
            // Some servers block default .NET user-agent; set a friendly one
            try
            {
                ImageHttpClient.DefaultRequestHeaders.UserAgent.ParseAdd("BookManagementApp/1.0");
            }
            catch { }
        }

        /// <summary>
        /// Load an image from a URL into a PictureBox asynchronously.
        /// On failure, sets the placeholder (may be null).
        /// </summary>
        public static async Task LoadIntoPictureBoxAsync(string url, PictureBox pb, Image placeholder = null, CancellationToken ct = default)
        {
            if (pb == null) return;
            if (string.IsNullOrWhiteSpace(url))
            {
                if (pb.IsHandleCreated)
                {
                    if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                    else pb.Image = placeholder;
                }
                return;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                if (pb.IsHandleCreated)
                {
                    if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                    else pb.Image = placeholder;
                }
                return;
            }

            try
            {
                using (var resp = await ImageHttpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    if (!resp.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine($"Image load failed ({resp.StatusCode}) for {url}");
                        if (pb.IsHandleCreated)
                        {
                            if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                            else pb.Image = placeholder;
                        }
                        return;
                    }

                    using (var stream = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var ms = new MemoryStream())
                    {
                        // use explicit buffer size overload: (destination, bufferSize, cancellationToken)
                        await stream.CopyToAsync(ms, 81920, ct).ConfigureAwait(false);
                        ms.Position = 0;
                        Image img;
                        try
                        {
                            img = Image.FromStream(ms);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid image format: {ex.Message}");
                            if (pb.IsHandleCreated)
                            {
                                if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                                else pb.Image = placeholder;
                            }
                            return;
                        }

                        if (pb.IsHandleCreated)
                        {
                            if (pb.InvokeRequired)
                            {
                                pb.Invoke(new Action(() =>
                                {
                                    var old = pb.Image;
                                    pb.Image = (Image)img.Clone();
                                    old?.Dispose();
                                }));
                            }
                            else
                            {
                                var old = pb.Image;
                                pb.Image = (Image)img.Clone();
                                old?.Dispose();
                            }
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // ignore
                if (pb.IsHandleCreated)
                {
                    if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                    else pb.Image = placeholder;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Load image failed for {url}: {ex.Message}");
                if (pb.IsHandleCreated)
                {
                    if (pb.InvokeRequired) pb.Invoke(new Action(() => pb.Image = placeholder));
                    else pb.Image = placeholder;
                }
            }
        }

        /// <summary>
        /// Fetches an Image from the provided URL and returns it. Returns null on failure.
        /// Caller receives a cloned Image and is responsible for disposing it when no longer needed.
        /// </summary>
        public static async Task<Image> LoadImageAsync(string url, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                return null;

            try
            {
                using (var resp = await ImageHttpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    if (!resp.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine($"Image load failed ({resp.StatusCode}) for {url}");
                        return null;
                    }
                    //stream nội dung từ HTTP response.
                    using (var stream = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var ms = new MemoryStream())
                    {
                        //sao chép toàn bộ dữ liệu từ stream(HTTP) vào ms(memory).
                        await stream.CopyToAsync(ms, 81920).ConfigureAwait(false);
                        ms.Position = 0; //reset con trỏ về đầu stream để đọc lại
                        // Tạo đối tượng img từ MenoryStream
                        Image img;
                        try
                        {
                            img = Image.FromStream(ms);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid image format: {ex.Message}");
                            return null;
                        }

                        try
                        {
                            // clone img và dọn dẹp
                            return (Image)img.Clone();
                        }
                        finally
                        {
                            img.Dispose();
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Load image failed for {url}: {ex.Message}");
                return null;
            }
        }
    }
}
