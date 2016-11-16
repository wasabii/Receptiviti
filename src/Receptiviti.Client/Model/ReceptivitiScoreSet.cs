using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class ReceptivitiScoreSet
    {

        #region Cofnitive/Thinking Style Insights

        [JsonProperty("thinking_style")]
        public double ThinkingStyle { get; set; }

        [JsonProperty("persuasive")]
        public double Persuasive { get; set; }

        [JsonProperty("reward_bias")]
        public double RewardBias { get; set; }

        #endregion

        #region Big 5 Insights

        [JsonProperty("openness")]
        public double Openness { get; set; }

        #region Group

        [JsonProperty("artistic")]
        public double Artistic { get; set; }

        [JsonProperty("intellectual")]
        public double Intellectual { get; set; }

        [JsonProperty("liberal")]
        public double Liberal { get; set; }

        [JsonProperty("imaginative")]
        public double Imaginative { get; set; }

        [JsonProperty("emotionally_aware")]
        public double EmotionallyAware { get; set; }

        [JsonProperty("adventurous")]
        public double Adventurous { get; set; }

        #endregion

        [JsonProperty("conscientiousness")]
        public double Conscientiousness { get; set; }

        #region Group

        [JsonProperty("self_assured")]
        public double SelfAssured { get; set; }

        [JsonProperty("disciplined")]
        public double Disciplined { get; set; }

        [JsonProperty("ambitious")]
        public double Ambitious { get; set; }

        [JsonProperty("dutiful")]
        public double Dutiful { get; set; }

        [JsonProperty("cautious")]
        public double Cautious { get; set; }

        [JsonProperty("organized")]
        public double Organized { get; set; }

        #endregion

        [JsonProperty("extraversion")]
        public double Extraversion { get; set; }

        #region Group

        [JsonProperty("socialble")]
        public double Sociable { get; set; }

        [JsonProperty("friendly")]
        public double Friendly { get; set; }

        [JsonProperty("assertive")]
        public double Assertive { get; set; }

        [JsonProperty("energetic")]
        public double Energetic { get; set; }

        [JsonProperty("cheerful")]
        public double Cheerful { get; set; }

        [JsonProperty("active")]
        public double Active { get; set; }

        #endregion

        [JsonProperty("agreeableness")]
        public double Agreeableness { get; set; }

        #region Group

        [JsonProperty("generous")]
        public double Generous { get; set; }

        [JsonProperty("trusting")]
        public double Trusting { get; set; }

        [JsonProperty("cooperative")]
        public double Cooperative { get; set; }

        [JsonProperty("empathetic")]
        public double Empathetic { get; set; }

        [JsonProperty("genuine")]
        public double Genuine { get; set; }

        [JsonProperty("humble")]
        public double Humble { get; set; }

        #endregion 

        [JsonProperty("neuroticism")]
        public double Neuroticism { get; set; }

        #region Group

        [JsonProperty("stressed")]
        public double Stressed { get; set; }

        [JsonProperty("anxious")]
        public double Anxious { get; set; }

        [JsonProperty("aggressive")]
        public double Aggressive { get; set; }

        [JsonProperty("melancholy")]
        public double Melancholy { get; set; }

        [JsonProperty("self_conscious")]
        public double SelfConscious { get; set; }

        #endregion

        #endregion

        #region Social Style Insights

        [JsonProperty("social_skills")]
        public double SocialSkills { get; set; }

        [JsonProperty("insecure")]
        public double Insecure { get; set; }

        [JsonProperty("cold")]
        public double Cold { get; set; }

        [JsonProperty("family_oriented")]
        public double FamilyOriented { get; set; }

        #endregion

        #region Emotional Style Insights

        [JsonProperty("adjustment")]
        public double Adjustment { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("impulsive")]
        public double Impulsive { get; set; }

        [JsonProperty("depression")]
        public double Depression { get; set; }

        #endregion

        #region Working Style Insights

        [JsonProperty("independent")]
        public double Independent { get; set; }

        [JsonProperty("power_driven")]
        public double PowerDriven { get; set; }

        [JsonProperty("type_a")]
        public double TypeA { get; set; }

        [JsonProperty("workhorse")]
        public double Workhorse { get; set; }

        #endregion

        #region Interests and Orientations

        [JsonProperty("friend_focus")]
        public double FriendFocus { get; set; }

        [JsonProperty("body_focus")]
        public double BodyFocus { get; set; }

        [JsonProperty("health_oriented")]
        public double HealthOriented { get; set; }

        [JsonProperty("sexual_focus")]
        public double SexualFocus { get; set; }

        [JsonProperty("food_focus")]
        public double FoodFocus { get; set; }

        [JsonProperty("leisure_oriented")]
        public double LeisureOriented { get; set; }

        [JsonProperty("money_oriented")]
        public double MoneyOriented { get; set; }

        [JsonProperty("religion_oriented")]
        public double ReligionOriented { get; set; }

        [JsonProperty("work_oriented")]
        public double WorkOriented { get; set; }

        [JsonProperty("netspeak_focus")]
        public double NetspeakFocus { get; set; }

        #endregion

    }

}
