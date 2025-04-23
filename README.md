Cosmetology Telegram Bot

A simple Telegram bot for a cosmetology studio. It provides information about services and allows users to send booking requests.



#Features
 
 • Responds to the /start command

 • Lists available cosmetology services
 
 • Accepts user booking requests
 
 • Clean and beginner-friendly C# implementation using the Telegram.Bot library




#Technologies
 
 • C#
 
 • .NET 8
 
 • Telegram.Bot v22 (NuGet package)




#How It Works

When the user interacts with the bot, it responds based on the message:
 
 • /start – welcome message
 
 • services – shows a list of services and prices
 
 • booking – asks for preferred date and time for the appointment
 
 • Any other message – returns a default response




#Services List
 
 • Facial cleansing — €50
 
 • Peeling — €60
 
 • Massage — €40
 
 • Lip augmentation — €200
 
 • Botox — €80




#Example

User: /start

Bot: Hi! I’m a cosmetology bot. Type ‘services’ or ‘booking’.

User: services

Bot:

Available services:

• Facial cleansing — €50

• Peeling — €60

• Massage — €40

• Lip augmentation — €200

• Botox — €80


User: booking

Bot: Please tell me your preferred date and time. A specialist will contact you to confirm the appointment.




#Getting Started
 1. Clone the repository:

 git clone https://github.com/Marianna6/Cosmetology_telegram_bot.git


 2. Add your bot token:
 To get the token, you can use BotFather on Telegram.
 Replace the placeholder in Main() with your token:

 var botClient = new TelegramBotClient("YOUR_TOKEN");


 3. Run the project in Visual Studio or from terminal:

 dotnet run





#Note

This bot does not use a database or handle actual appointment bookings — it only collects user input for simulation purposes. It can be expanded later with backend or calendar integration.




#License

MIT — free to use and modify.
