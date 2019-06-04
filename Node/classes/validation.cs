using System;
using Newtonsoft.Json.Linq;

namespace Node.Classes {
    public static class Validation {
        public static bool validateBlock (JObject incomingBlock, JArray current_chain) {
            // return checkTimestamp (current_chain, incomingBlock);
            if (checkTimestamp (current_chain, incomingBlock) && checkHashOfLastBlockInCurrentChain (current_chain, incomingBlock)) {
                // validated
                return true;
            } else {
                // notvalidated
                return false;
            }
        }

        public static bool checkTimestamp (JArray current_chain, JObject incomingBlock) {
            var latestBlock = current_chain.Last;
            DateTime timestampLatestBlock = Convert.ToDateTime ((string) latestBlock["timestamp"]);
            DateTime timestampIncomingBlock = Convert.ToDateTime ((string) incomingBlock["timestamp"]);
            if (timestampIncomingBlock > timestampLatestBlock) {
                return true;
            } else {
                return false;
            }
        }

        public static bool checkHashOfLastBlockInCurrentChain (JArray current_chain, JObject incomingBlock) {
            string incomingPreviousHash = (string) incomingBlock["previous_hash"];
            if (calculateHashOfLatestBlockInCurrentChain (current_chain) == incomingPreviousHash) {
                return true;
            } else {
                return true;
            }
        }

        public static string calculateHashOfLatestBlockInCurrentChain (JArray current_chain) { //returns hash
            var latestBlock = current_chain.Last;
            // return mennoFunctie.hash(latestBlock)
            return "dit is een hash";
        }

    }
}