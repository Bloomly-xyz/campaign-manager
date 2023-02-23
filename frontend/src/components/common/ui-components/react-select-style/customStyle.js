export const customStyles = {
  container: (provided ,state) => ({
    ...provided,
    
   
  }),
  control: (provided ,state) => ({
    ...provided,
    backgroundColor: "transparent",
    border: "none",
    boxShadow: "none",
    cursor: "pointer",
    paddingTop:'6px',
    paddingBottom:'7px',
    paddingRight:'6px',
    paddingLeft:'0px',
    borderBottom: state?.isFocused ? "1px solid #12221ab3" :  "1px solid #12221a1a",
    borderTop:'none',
    borderLeft:'none',
    borderRight:'none',
    borderRadius:'0px'
   
  }),
  menu: (provided) => ({
    ...provided,
    
    backgroundColor: "white",
    color: "#12221A",
    WebkitScrollbar: { width: "2px", backgroundColor: "red" },
    WebkitScrollbarTrack: {
      borderRadius: "3px",
    },
    WebkitScrollbarThumb: {
      background: "grey",
      borderRadius: "3px",
    },
    
  }),
  menuList: (base) => ({
    ...base,
    paddingBottom:"24px",
    maxHeight:"250px",
    "::-webkit-scrollbar": {
      width: "8px",
      height: "0px",
      
      
    },
    "::-webkit-scrollbar-track": {
      background: "#A5F33C",
     
    },
    "::-webkit-scrollbar-thumb": {
      background: "#a5f33c3d",
      minHeight:"60px",
      borderRight :"8px solid #222222",
    },
    "::-webkit-scrollbar-thumb:hover": {
      background: "#a5f33c3d",
    },
  }),
  option: (provided,state ) => ({
    ...provided,
    color:state?.isFocused ? 'white' : '#12221A',
    backgroundColor:state?.isFocused ? "#12221A" : "#12221a05",
   
    ":hover": {
      backgroundColor: "#12221A",
      color: "white",
    },
    
  }),
  input: (provided, state) => ({
    ...provided,
    color: "12221A",
  }),

  singleValue: (provided) => ({
    ...provided,
    color: "white",
  }),
  indicatorsContainer: (provided) => ({
    ...provided,
    backgroundColor: "transparent",
    color: "white",
    
  }),
  indicatorSeparator:(provided) => ({
      ...provided,
      backgroundColor: "transparent",
      
      
    }),
    valueContainer:(provided) => ({
      ...provided,
      paddingTop:'2px',
    paddingBottom:'2px',
    paddingRight:'8px',
    paddingLeft:'0px'
      
      
    }),
 
};