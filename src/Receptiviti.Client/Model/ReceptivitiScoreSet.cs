using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class ReceptivitiScoreSet
    {
        
        [JsonProperty("independent")]
        public double Independent { get; set; }
        
        [JsonProperty("type_a")]
        public double TypeA { get; set; }
        
        [JsonProperty("workhorse")]
        public double Workhorse { get; set; }
        
        [JsonProperty("thinking_style")]
        public double ThinkingStyle { get; set; }
        
        [JsonProperty("marketing_iq")]
        public double MarketingIQ { get; set; }
        
        [JsonProperty("insecure")]
        public double Insecure { get; set; }
        
        [JsonProperty("conscientious")]
        public double Conscientious { get; set; }
        
        [JsonProperty("reward_bias")]
        public double RewardBias { get; set; }
        
        [JsonProperty("impulsive")]
        public double Impulsive { get; set; }
        
        [JsonProperty("family_oriented")]
        public double FamilyOriented { get; set; }
        
        [JsonProperty("achievment_driven")]
        public double AchievementDriven { get; set; }

        [JsonProperty("extraversion")]
        public double Extraversion { get; set; }
        
        [JsonProperty("neuroticism")]
        public double Neuroticism { get; set; }
        
        [JsonProperty("happiness")]
        public double Happiness { get; set; }
        
        [JsonProperty("social_skills")]
        public double SocialSkills { get; set; }
        
        [JsonProperty("power_driven")]
        public double PowerDriven { get; set; }
        
        [JsonProperty("cold")]
        public double Cold { get; set; }
        
        [JsonProperty("adjustment")]
        public double Adjustment { get; set; }
        
        [JsonProperty("openness")]
        public double Openness { get; set; }
        
        [JsonProperty("agreeable")]
        public double Agreeable { get; set; }
        
        [JsonProperty("depression")]
        public double Depression { get; set; }

    }

}
