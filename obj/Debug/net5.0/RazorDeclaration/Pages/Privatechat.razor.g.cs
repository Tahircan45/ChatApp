// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ChatApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Hubs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\_Imports.razor"
using ChatApp.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\Pages\Privatechat.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/privatechat")]
    public partial class Privatechat : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\tahir\OneDrive\Masaüstü\New folder\ChatApp\Pages\Privatechat.razor"
       
    private HubConnection hubConnection;
    private List<Message> messages = new List<Message>();
    private string userInput;
    private string messageInput;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Message mess = new Message();
            mess.Content = message;
            mess.UserName = user;
            messages.Add(mess);
            StateHasChanged();
        });

        await hubConnection.StartAsync();
        messages = await mService.GetMessages();
    }
    public void Send()
    {
        SendHub();
        SendDb();
        messageInput = null;
    }
    Task SendHub() =>
        hubConnection.SendAsync("SendMessage", userInput, messageInput);
    public void SendDb()
    {
        Message mess = new Message();
        mess.Content = messageInput;
        mess.UserName = userInput;
        mService.AddMessage(mess);
    }

    public bool IsConnected =>
        hubConnection.State == HubConnectionState.Connected;

    public void Dispose()
    {
        _ = hubConnection.DisposeAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMessageService mService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
