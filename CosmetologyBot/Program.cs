using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;

class Program
{
	static async Task Main()
	{
		var botClient = new TelegramBotClient("TOKEN"); // Token from BotFather

		using var cts = new CancellationTokenSource();

		var receiverOptions = new ReceiverOptions
		{
			AllowedUpdates = new UpdateType[0] // receiving all types of updates
			// Using a basic empty array of UpdateType to allow all types of updates.Alternatively, Array.Empty<UpdateType>() could be used — it's slightly more efficient, but for now I chose a more readable approach that helps me understand the code better.
		};

		botClient.StartReceiving(
			HandleUpdateAsync,
			HandleErrorAsync,
			receiverOptions,
			cancellationToken: cts.Token
		);

		var me = await botClient.GetMeAsync();
		Console.WriteLine($"Bot {me.Username} started.");
		Console.ReadLine();

		// Stop the bot when Enter is pressed
		cts.Cancel();
	}
	// This method handles incoming user messages
	static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
	{
		// Check if there is a message and text
		if (update.Message == null || update.Message.Text == null)
			return;

		var messageText = update.Message.Text.ToLower();
		var chatId = update.Message.Chat.Id;

		Console.WriteLine($"Received message:  '{messageText}' from {chatId}");

		string responseText = messageText switch
		{
			"/start" => "Hi! I'm a cosmetology bot. Type 'services' or 'booking'.",
			"services" => "Available services:\n- Facial cleansing — €50\n- Peeling — €60\n- Massage — €40\n- Lip augmentation — €200\n- Botox — €80",
			"booking" => "Please tell me your preferred date and time.",
			_ => "Sorry, I didn't understand that. Type /start to begin."
		};
		// This method sends messages to the user
		await botClient.SendTextMessageAsync(
			chatId: chatId,
			text: responseText,
			cancellationToken: cancellationToken
		);
	}
	// This method handles any errors that occur during execution
	static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
	{
		var errorMessage = exception switch
		{
			ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}] {apiRequestException.Message}",
			_ => exception.ToString()
		};

		Console.WriteLine(errorMessage);
		return Task.CompletedTask;
	}
}