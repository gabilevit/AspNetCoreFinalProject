using AspNetCoreFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFinalProject.Data
{
    public class PetSiteContext : DbContext
    {
        public PetSiteContext(DbContextOptions<PetSiteContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Name = "Abyssinian Cat", Age = 3, Picturename = "/images/Cats/AbyssinianCat.jpg", Description = "Abyssinians are highly intelligent and intensely inquisitive. They love to investigate and will leave no nook or cranny unexplored. They’re sometimes referred to as “Aby-grabbys” because they tend to take things that grab their interest. The playful Aby loves to jump and climb. Keep a variety of toys on hand to keep her occupied, including puzzle toys that challenge her intelligence.", CategoryId = 1 },
                new { Id = 2, Name = "American Bobtail Cat", Age = 6, Picturename = "/images/Cats/AmericanBobtailCat.jpg", Description = "The American Bobtail is an athletic breed that looks like a bobtailed wildcat and has many dog-like tendencies.", CategoryId = 1 },
                new { Id = 3, Name = "Birman Cat", Age = 4, Picturename = "/images/Cats/BirmanCat.jpg", Description = "The Birman is a cat of distinction as well as legend. With their exotic ancestry, luxurious pointed coats, “white gloved” paws and mesmerizing blue eyes, this is a breed with undeniable charisma.", CategoryId = 1 },
                new { Id = 4, Name = "Chartreux Cat", Age = 3, Picturename = "/images/Cats/ChartreuxCat.jpg", Description = "Often called the smiling cat of France, the Chartreux has a sweet, smiling expression. This sturdy, powerful cat has a distinctive blue coat with a resilient wooly undercoat. Historically known as fine mousers with strong hunting instincts, the Chartreux enjoys toys that move. ", CategoryId = 1 },
                new { Id = 5, Name = "Exotic Shorthair Cat", Age = 7, Picturename = "/images/Cats/ExoticShorthairCat.jpg", Description = "Known as the lazy man’s Persian, the Exotic Shorthair has the body type and easygoing nature of the Persian but without the coat length and need for daily grooming.", CategoryId = 1 },
                new { Id = 6, Name = "Japanese Bobtail Cat", Age = 2, Picturename = "/images/Cats/JapaneseBobtailCat.jpg", Description = "One of the oldest cat breeds, the Japanese Bobtail is believed to bring good luck and prosperity. The two coat varieties, longhair and shorthair, are exactly the same except for coat length. ", CategoryId = 1 },
                new { Id = 7, Name = "LaPerm Cat", Age = 5, Picturename = "/images/Cats/LaPermCat.jpg", Description = "Distinguished by her curly, rippled coat and people-oriented personality, the LaPerm is calm and friendly, yet at other times energetic and inquisitive. This feline thrives on attention and likes to be close to her human companions.", CategoryId = 1 },
                new { Id = 8, Name = "Norwegian Forest Cat", Age = 3, Picturename = "/images/Cats/NorwegianForestCat.jpg", Description = "The Norwegian Forest Cat is a gentle giant. They’re large and athletic, so you may find them sitting atop the highest point in your home, and they have no qualms about jumping down. Norwegian Forest Cats are fond of their family but are reserved with visitors.", CategoryId = 1 },
                new { Id = 9, Name = "Siberian Cat", Age = 9, Picturename = "/images/Cats/SiberianCat.jpg", Description = "This friendly and affectionate feline will follow you around as you go about your day, and purr in your lap as you comb her coat. Siberian Cats love their humans but aren’t shy around strangers.", CategoryId = 1 },
                new { Id = 10, Name = "Somali Cat", Age = 8, Picturename = "/images/Cats/SomaliCat.jpg", Description = "Strikingly beautiful, the Somali looks like a small wild fox with her full bushy tail and britches, large ears and dramatically ticked coat. This highly intelligent feline is known to open cupboards and fetch toys. The Somali loves attention and affection.", CategoryId = 1 },
                new { Id = 11, Name = "American Eskimo Dog", Age = 13, Picturename = "/images/Dogs/AmericanEskimoDog.jpg", Description = "The American Eskimo Dog, which descended from European spitz-type dogs, was brought to the U.S. by German immigrants. The breed comes in three size varieties: Standard, Miniature and Toy. ", CategoryId = 2 },
                new { Id = 12, Name = "Bulldog", Age = 10, Picturename = "/images/Dogs/Bulldog.jpg", Description = "Bulldogs are a popular breed known for their lovable disposition and charming wrinkles. Resolute and courageous, this breed is an excellent family companion, requiring minimal grooming and exercise.", CategoryId = 2 },
                new { Id = 13, Name = "Chihuahua", Age = 3, Picturename = "/images/Dogs/Chihuahua.jpg", Description = "The Chihuahua sports a big attitude in a petite body. One of the most widely-recognized “purse dogs,” this toy breed rules homes and hearts with his loyalty, charm and confidence.", CategoryId = 2 },
                new { Id = 14, Name = "Chow Chow", Age = 5, Picturename = "/images/Dogs/ChowChow.jpg", Description = "A regal breed with strong muscles and heavy boned, the Chow Chow is an ancient breed from northern China. Although affectionate, he can be stubborn.", CategoryId = 2 },
                new { Id = 15, Name = "Dalmatian", Age = 9, Picturename = "/images/Dogs/Dalmatian.jpg", Description = "The Dalmatian is the original coach dog, well known for riding proudly atop a fire engine or running with a carriage. Dalmatians are both smart and muscular, with stamina to keep up the pace.", CategoryId = 2 },
                new { Id = 16, Name = "German Shepherd", Age = 7, Picturename = "/images/Dogs/GermanShepherd.jpg", Description = "Hailed as the world’s leading military, police and guard dog, the German Shepherd Dog is a large, agile, muscular dog known for his loyalty and high intelligence.", CategoryId = 2 },
                new { Id = 17, Name = "Labrador Retriever", Age = 16, Picturename = "/images/Dogs/LabradorRetriever.jpg", Description = "The Labrador Retriever is a friendly, intelligent breed, which might explain why Labs are America’s favorite dogs.", CategoryId = 2 },
                new { Id = 18, Name = "Pomeranian", Age = 13, Picturename = "/images/Dogs/Pomeranian.jpg", Description = "The Pomeranian is a cocky and animated Nordic dog with great intelligence, making him a great family pet. His smiling, foxy face and vivacious personality makes him one of the world’s most popular toy breeds.", CategoryId = 2 },
                new { Id = 19, Name = "Pug", Age = 3, Picturename = "/images/Dogs/Pug.jpg", Description = "The small but solid Pug is adored for his playful personality. These cute little dogs are one of the oldest breeds, and they love to love—and be loved in return.", CategoryId = 2 },
                new { Id = 20, Name = "Rottweiler", Age = 8, Picturename = "/images/Dogs/Rottweiler.jpg", Description = "The Rottweiler is a muscular, courageous and devoted dog breed. Descended from Roman drover dogs, they were originally used to move and guide herds of the Roman army.", CategoryId = 2 },
                new { Id = 21, Name = "African Gray Parrot", Age = 2, Picturename = "/images/Birds/AfricanGrayParrot.jpg", Description = "The African Grey is believed to have originated in the West and Central African rainforests. It is widely considered as among the smartest birds in the world, earning them the title as the “thinking man’s” bird.", CategoryId = 3 },
                new { Id = 22, Name = "Border Canary", Age = 1, Picturename = "/images/Birds/BorderCanary.jpg", Description = "Border Canaries are the result of the evolution of common canary. They were bred in the Scottish Borders and the North of England in the 1700s. ", CategoryId = 3 },
                new { Id = 23, Name = "Burrowing Owl", Age = 5, Picturename = "/images/Birds/BurrowingOwl.jpg", Description = "Burrowing Owls are small but long-legged birds found throughout the South and North America. They earned such a name because they love to roost and nest in burrows.", CategoryId = 3 },
                new { Id = 24, Name = "Crimson Rosella", Age = 3, Picturename = "/images/Birds/CrimsonRosella.jpg", Description = "Crimson Rosellas are parrots that are found in the eastern and southeastern Australia. They are around 14 inches long. Young birds are mainly green, but they turn red as they get older.", CategoryId = 3 },
                new { Id = 25, Name = "Emerald Toucanet", Age = 4, Picturename = "/images/Birds/EmeraldToucanet.jpg", Description = "Emerald Toucanets are noted for their large bill and brightly marked colours. Both males and females look alike, except for the fact that females are smaller with a shorter bill. ", CategoryId = 3 },
                new { Id = 26, Name = "Hyacinth Macaw", Age = 22, Picturename = "/images/Birds/HyacinthMacaw.jpg", Description = "Hyacinth Macaws are large birds that are about 40 inches tall. They are native to South America and can live for around 60 to 80 years. ", CategoryId = 3 },
                new { Id = 27, Name = "Mealy Amazon", Age = 16, Picturename = "/images/Birds/MealyAmazon.jpg", Description = "Mealy Amazons are one of the largest parrots among the Amazon species. They are mainly green and are 38 to 41 inches tall. ", CategoryId = 3 },
                new { Id = 28, Name = "Northern Cardinal", Age = 12, Picturename = "/images/Birds/NorthernCardinal.jpg", Description = "Northern Cardinals are mid-sized songbirds that are around 8.3 inches tall. They are noted for their crest on the head as well as the mask on their face. ", CategoryId = 3 },
                new { Id = 29, Name = "Wandering Albatross", Age = 32, Picturename = "/images/Birds/WanderingAlbatross.jpg", Description = "The Wandering Albatross is a seabird that is found in the Southern Ocean. It is one of the biggest birds in the world and has been featured in many avian studies. ", CategoryId = 3 },
                new { Id = 30, Name = "Willet", Age = 28, Picturename = "/images/Birds/Willet.jpg", Description = "Willets are large shorebirds with a stout bill. They have grey legs, a dark grey body, and a white tail with a white tip. Their wings have a black and white pattern.", CategoryId = 3 }
            );

            modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Cat" },
            new { Id = 2, Name = "Dog" },
            new { Id = 3, Name = "Bird" }
            );

            modelBuilder.Entity<Comment>().HasData(
            new { Id = 1, Info = "Nice cat! 10/10", AnimalId = 1 },
            new { Id = 2, Info = "I like his color", AnimalId = 3 },
            new { Id = 3, Info = "Where can i buy one?", AnimalId = 6 },
            new { Id = 4, Info = "Such a beutifull creture..", AnimalId = 6 },
            new { Id = 5, Info = "Wow he is so cute", AnimalId = 7 },
            new { Id = 6, Info = "I had once a LaPerm Cat", AnimalId = 7 },
            new { Id = 7, Info = "Didnt like this cat al all:(", AnimalId = 7 },
            new { Id = 8, Info = "Its very cold there wow he surviving", AnimalId = 9 },
            new { Id = 9, Info = "Its time for africa", AnimalId = 10 },
            new { Id = 10, Info = "Lol its a pirate cat", AnimalId = 10 },
            new { Id = 11, Info = "Dogs are the best pet in the worldddddd", AnimalId = 12 },
            new { Id = 12, Info = "There is a movie in hollywood about this kind of breed", AnimalId = 13 },
            new { Id = 13, Info = "They are small but hella angry", AnimalId = 13 },
            new { Id = 14, Info = "My dad got me one for my birthday", AnimalId = 13 },
            new { Id = 15, Info = "Eww this dog i dont like", AnimalId = 15 },
            new { Id = 16, Info = "Best dog for military and pollice", AnimalId = 16 },
            new { Id = 17, Info = "The best friend for a human", AnimalId = 17 },
            new { Id = 18, Info = "When someone says dog this this kind of dog i think of", AnimalId = 17 },
            new { Id = 19, Info = "tyv587nyo8yt8vrrter", AnimalId = 17 },
            new { Id = 20, Info = "So inoccent", AnimalId = 17 },
            new { Id = 21, Info = "woof woof", AnimalId = 17 },
            new { Id = 22, Info = "Pug is small and stinkey", AnimalId = 19 },
            new { Id = 23, Info = "Birds are the best:)", AnimalId = 22 },
            new { Id = 24, Info = "Hes scary at night", AnimalId = 23 },
            new { Id = 25, Info = "Welcome to the jungle", AnimalId = 25 },
            new { Id = 26, Info = "Is this bird from Brazil?", AnimalId = 27 },
            new { Id = 27, Info = "This bird is so green i cant see her even", AnimalId = 27 },
            new { Id = 28, Info = "First comment lolololol", AnimalId = 30 }
            );
        }        
    }
}
