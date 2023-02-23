import React, { useState } from 'react'
import images from '../../../constants/images-constants/images';
import SearchComponent from '../../common/ui-components/SearchComponent'

import {
  Tab,
  TabBody,
  TabComponent,
  TabHeader,
  TabPanel,
} from "../../common/ui-components/tabs-component/tabs";
import AllUtility from './AttachUtilityComponents/AllUtility';
import PhysicalUtility from './AttachUtilityComponents/PhysicalUtility';



const AttachUtility = (props) => {
  const { selectedUtility, setSelectedUtility, setOpenUtilityForm, setActiveStep, utilitiesListing,setUtilitiesListing ,filterData } = props;
  const [openTab, setOpenTab] = useState(1);
  const data = utilitiesListing?.map((data, i) => {
    return {
      title: data?.utitilityName,
      description: data?.utilityDescription,
      value: data?.id,
      type: data?.physical ? "Physical" : data?.digital ? "Digital" : data?.expeiential ? "Experiential" : "",
      image: data?.id === 1 ? images.PenIcon : data?.id === 2 ? images.MerchIcon : (data?.id === 3 || data?.id === 10) ? images.AudioIcon : 
      (data?.id === 4 || data?.id === 6) ? images.EventIcon : data?.id === 5 ? images.QuestionIcon
        : data?.id === 7 ? images.PromocodeIcon : data?.id === 8 ? images.TicketsIcon : data?.id === 9 ? images.NewsletterIcon : ""
    }
  });


  return (
    <>
      <div className="p-6 rounded-3xl">
        <div className='max-w-[714px] mb-6'>
          <SearchComponent filterData={filterData} setUtilitiesListing={setUtilitiesListing}/>
        </div>
        <div>
          <TabComponent>
            <TabHeader>
              <Tab openTab={openTab} setOpenTab={setOpenTab} value={1}>
                ALL
              </Tab>
              <Tab openTab={openTab} setOpenTab={setOpenTab} value={2}>
                Physical
              </Tab>
              <Tab openTab={openTab} setOpenTab={setOpenTab} value={3}>
                Digital
              </Tab>
              <Tab openTab={openTab} setOpenTab={setOpenTab} value={4}>
                Experiential
              </Tab>

            </TabHeader>
            <TabBody>
              <TabPanel openTab={openTab} value={1}>
                <AllUtility data={data} setActiveStep={setActiveStep} setOpenUtilityForm={setOpenUtilityForm} selectedUtility={selectedUtility} setSelectedUtility={setSelectedUtility} />
              </TabPanel>
              <TabPanel openTab={openTab} value={2}>
                <PhysicalUtility data={data} setActiveStep={setActiveStep} setOpenUtilityForm={setOpenUtilityForm} selectedUtility={selectedUtility} setSelectedUtility={setSelectedUtility} />
              </TabPanel>
              <TabPanel openTab={openTab} value={3}>
                <p className='font-extrabold text-center '> Coming soon </p>
              </TabPanel>
              <TabPanel openTab={openTab} value={4}>
                <p className='font-extrabold text-center '> Coming soon </p>
              </TabPanel>

            </TabBody>
          </TabComponent>
        </div>
      </div>
    </>
  )
}

export default AttachUtility