using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using NamePronunciation.Data.Repo;
using NamePronunciation.Entities;
using NamePronunciation.Models;
using NAudio.Wave;

namespace NamePronunciation.Services.Implementation
{
    public class PronunciationService:IPronunciationService
        
    {
        private readonly IDataRepository repository;
        public PronunciationService(IDataRepository repository)
        {
            this.repository = repository;
        }
        public void  GetcustomAudioFileandSave(string input)
        {
            input = "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";
            byte[] audio = Convert.FromBase64String(input);
            var fileName = "Employee7";
            var filePath = @"C:\\Temp\\" + fileName;
            string newfilename = Path.ChangeExtension(filePath, ".m4a");
            FileStream stream = new FileStream(newfilename, FileMode.Append, FileAccess.Write);
            System.IO.BinaryWriter br = new BinaryWriter(stream);
            br.Write(audio);
            br.Close();
        }
        public void GetExistingPronunciation(string Name)
        {
            Employee emp = new Employee();
            emp=this.repository.GetEmployeeDetails(Name);
            SoundPlayer simpleSound = new SoundPlayer(emp.AudioPath);
            simpleSound.Play();
        }
        public void GetStandardPronunciation(string Name)
        {
            using (SpeechSynthesizer speech = new SpeechSynthesizer())
            {
                speech.Volume = 100;
                speech.Rate = -2;
                speech.Speak(Name);
            }
            
            var fileName = Name;
            var filePath = @"C:\\Temp\\" + fileName;
            string newfilename = Path.ChangeExtension(filePath, ".m4a");
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = 100;
            synth.Rate = -2;
            synth.SetOutputToWaveFile(newfilename);
            synth.Speak(Name);
            // Set the synthesizer output to null to release the stream.   

            synth.SetOutputToDefaultAudioDevice();
            synth.SetOutputToNull();
            repository.saveAudioChanges(Name, newfilename);
        }

        

        public string GetPhoneticsforName(string Name)
        {
            string MyText = Name; // Initialze string for storing word (or words) of interest
            string MyPronunciation = GetPronunciationFromText(MyText.Trim()); // Get IPA pronunciations of MyTe
            Console.WriteLine(MyText + " = " + MyPronunciation); // Output MyText and MyPronunciation
            return MyPronunciation;
        }

        public static string recoPhonemes;

        public static string GetPronunciationFromText(string MyWord)
        {
            //this is a trick to figure out phonemes used by synthesis engine

            //txt to wav
            using (MemoryStream audioStream = new MemoryStream())
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.SetOutputToWaveStream(audioStream);
                    PromptBuilder pb = new PromptBuilder();
                    //pb.AppendBreak(PromptBreak.ExtraSmall); //'e' wont be recognized if this is large, or non-existent?
                    //synth.Speak(pb);
                    synth.Speak(MyWord);
                  
                    //synth.Speak(pb);
                    synth.SetOutputToNull();
                    audioStream.Position = 0;

                    //now wav to txt (for reco phonemes)
                    recoPhonemes = String.Empty;
                    GrammarBuilder gb = new GrammarBuilder(MyWord);
                    Grammar g = new Grammar(gb); //TODO the hard letters to recognize are 'g' and 'e'
                    SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
                    reco.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(reco_SpeechHypothesized);
                    reco.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(reco_SpeechRecognitionRejected);
                    reco.UnloadAllGrammars(); //only use the one word grammar
                    reco.LoadGrammar(g);
                    reco.SetInputToWaveStream(audioStream);
                    RecognitionResult rr = reco.Recognize();
                    reco.SetInputToNull();
                    if (rr != null)
                    {
                        recoPhonemes = StringFromWordArray(rr.Words, WordType.Pronunciation);
                    }
                    //txtRecoPho.Text = recoPhonemes;
                    return recoPhonemes;
                }
            }
        }

        public static string StringFromWordArray(ReadOnlyCollection<RecognizedWordUnit> words, WordType type)
        {
            string text = "";
            foreach (RecognizedWordUnit word in words)
            {
                string wordText = "";
                if (type == WordType.Text || type == WordType.Normalized)
                {
                    wordText = word.Text;
                }
                else if (type == WordType.Lexical)
                {
                    wordText = word.LexicalForm;
                }
                else if (type == WordType.Pronunciation)
                {
                    wordText = word.Pronunciation;
                    //MessageBox.Show(word.LexicalForm);
                }
                else
                {
                    throw new InvalidEnumArgumentException(String.Format("[0}: is not a valid input", type));
                }
                //Use display attribute

                if ((word.DisplayAttributes & DisplayAttributes.OneTrailingSpace) != 0)
                {
                    wordText += " ";
                }
                if ((word.DisplayAttributes & DisplayAttributes.TwoTrailingSpaces) != 0)
                {
                    wordText += "  ";
                }
                if ((word.DisplayAttributes & DisplayAttributes.ConsumeLeadingSpaces) != 0)
                {
                    wordText = wordText.TrimStart();
                }
                if ((word.DisplayAttributes & DisplayAttributes.ZeroTrailingSpaces) != 0)
                {
                    wordText = wordText.TrimEnd();
                }

                text += wordText;

            }
            return text;
        }

        public static void reco_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
        }

        public static void reco_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
        }

    }

    public enum WordType
    {
        Text,
        Normalized = Text,
        Lexical,
        Pronunciation
    }
}

