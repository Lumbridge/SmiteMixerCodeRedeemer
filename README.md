# Smite Mixer Code Redeemer
This application will monitor the smite mixer chat for chest codes and redeem them using the PC game client.  

# Usage
## !!! NOTE: If you want to use automatic code redemption make sure the SMITE Game Client is open in Windowed Mode at 1920x1080 resolution !!!
## AFK Mode
AFK mode will fully automate the code redemption process. It will read codes from the mixer chat (no need to have the stream open in browser), then it will bring the Smite game client to the foreground, go to the store, go to the redeem code tab, type the code and click the redeem button.
## Semi Manual Mode
There are two buttons below the Active Codes listbox which allow you to manually trigger the redemption process outlined in the AFK Mode section. (More info below).
## Redeem Selected Code
This button will automatically redeem the code which is selected in the Active Codes listbox.
## Redeem All Active Codes
This button will automatically loop through all the active codes and redeem them all one after another.
## Whitelist
The Whitelist allows you to control which messages the Grabber will read, if the Whitelist is populated and the option is enabled then it will only read messages from the usernames in the Whitelist. If the whitelist is not being used then the grabber will read all user messages and if it finds a potentially valid code* then it will be added to the active codes for redemption.
## Code Validity*
The grabber finds codes by reading through a user's message, if the message contains the characters contained in the "Codes Begin With" box and the word it was found in is the same length as the number set in the "Codes are XX characters long box" and the word contains no whitespace then the Grabber has found a potentially valid match which will be added to the active codes list.
## Notifications
If you don't want to use the automation modes built into the grabber then you can opt to recieve notifications of when a new code is added to the active codes list.

# Credits
Credits to myself for Dolphin Script, SmiteMixerListenerCLI and SmiteMixerListenerGUI Projects,  
Credits to https://github.com/breeser/ for the mixer chat API.  
