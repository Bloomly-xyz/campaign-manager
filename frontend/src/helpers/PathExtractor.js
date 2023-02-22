import React from 'react'

const PathExtractor = () => {
    const extractContractPath = (pathName, contract) => {
        let regex = pathName === "storage" ? /(\/storage\/.*?(?=,|\)|;|\n|[ ]|}))/ig : pathName === "public" ? /(\/public\/.*?(?=,|\)|;|\n|[ ]|}))/ig : "";

        // Alternative syntax using RegExp constructor
        // const regex = new RegExp('\\b(.*to:)( ?)*(\\/storage\\/)\\S*(\\\\n|;| |\\))', 'gm')

        let m;
        let paths = [];
        while ((m = regex.exec(contract)) !== null) {
            // This is necessary to avoid infinite loops with zero-width matches
            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }

            // The result can be accessed through the `m`-variable.
            m.forEach((match, groupIndex) => {
                if (groupIndex === 1){
                   
                    paths.push(match);
                }
                
            });
        }
        paths= [...new Set(paths)];
        return paths;
    }
    return {
        extractContractPath
    }
}

export default PathExtractor