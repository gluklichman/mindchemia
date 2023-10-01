using System;
using System.Collections.Generic;
using UnityEngine;

public class WordConfig
{
    [Serializable]
    public class WordConfigData
    {
        public WordData[] good_words;
        public WordData[] bad_words;
        public MatchRuleData[] match_rules;
        public AnnihilationRuleData[] annihilation_rules;
    }

    [Serializable]
    public class WordData
    {
        public string id;
        public string text;
    }

    [Serializable]
    public class MatchRuleData
    {
        public string id1;
        public string id2;
        public string result;
    }

    [Serializable]
    public class AnnihilationRuleData
    {
        public string good;
        public string bad;
    }

    private WordConfigData _data;

    public WordConfig()
    {
        TextAsset configAsset = Resources.Load("Configs/words_config") as TextAsset;
        _data = JsonUtility.FromJson<WordConfigData>(configAsset.text);
        Debug.Log("config loaded");
    }

    public WordData GetGoodWord(string id)
    {
        return Array.Find(_data.good_words, word => word.id == id);
    }

    public WordData GetBadWord(string id)
    {
        return Array.Find(_data.bad_words, word => word.id == id);
    }

    public WordData TryPerformMatch(string id1, string id2)
    {
        MatchRuleData matchRule = GetMatchRuleForWords(id1, id2);
        if (matchRule != null)
        {
            return GetGoodWord(matchRule.result);   
        }
        return null;
    }

    private MatchRuleData GetMatchRuleForWords(string w1, string w2)
    {
        foreach (MatchRuleData rule in _data.match_rules)
        {
            if (rule.id1 == w1 && rule.id2 == w2)
            {
                return rule;
            }
            if (rule.id2 == w1 && rule.id1 == w2)
            {
                return rule;
            }
        }
        return null;
    }
}
