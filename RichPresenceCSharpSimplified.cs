		//Tools > NuGet Package Manager > Package Manager Console > Type: Install-Package DiscordRichPresence
		
        //Then Add These Anywhere In Your Main Form cs File.
		
        //Then Add A Call To InitializeRPC(); In Your Form_Load
		
        //Finally, Make A Timer And Add UpdatePresence(); To It's Tick Param (Double Click The Timer To Create)
		
		//Enjoy! - By ZuKuTo / OFWModz
		
		//Define Client Used To Set/Send Rich Presence Updates
        private DiscordRpcClient client;
		
        //Fix For Time Resetting To 00:00 Each Update
        private Timestamps Time;
		
        //Set Client ID And Connect To The Discord App's Rich Presence API
        private void InitializeRPC()
        {
            //Client ID For Images Via Names, Client ID Name (Name Of Tool/Program At Top Of Rich Presence - Clickable
            client = new DiscordRpcClient("574289983201083392");

            //Connect To The Discord App's Rich Presence API
            client.Initialize();
        }
		
        private void UpdatePresence()
        {
			//Last Two Version Numbers, For Example My One As Of Writing This Is 0.0.2.5
            string CurrentVersionNumber = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision;
			
            if (filename != null && treeView1.SelectedNode != null)
            {
                if (Time == null)
                {
                    //Only Define Timestamp Once - Fix For Time Resetting To 00:00 Each Update - Only Done Once Project Is Opened And File Is Selected
                    Time = Timestamps.Now;
                }
				
				//Define New RichPresence And Set/Update It
                client.SetPresence(new RichPresence()
                {
                    Details = "Project: " + filename,
                    State = "File: " + treeView1.SelectedNode.Text,
                    Timestamps = Time,
                    Assets = new Assets()
                    {
                        LargeImageKey = "main_logo",
						LargeImageText = "Poppy's FF Editor v" + CurrentVersionNumber + Environment.NewLine + "Project: " + filename + Environment.NewLine + "Created By OFWModz",
                        SmallImageKey = "cfg_file",
                        SmallImageText = "File: " + treeView1.SelectedNode.Text,
                    }
                });
            }
            else
            {
				//Define New RichPresence And Set/Update It
                client.SetPresence(new RichPresence()
                {
                    Details = "Idle",
                    Assets = new Assets()
                    {
                        LargeImageKey = "main_logo",
                        LargeImageText = "Poppy's FF Editor v" + CurrentVersionNumber + Environment.NewLine + "Created By OFWModz"
                    }
                });
            }
        }