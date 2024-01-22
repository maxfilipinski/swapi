import { CircularProgress, List, ListItem, ListItemText } from "@mui/material";
import MovieIcon from "@mui/icons-material/Movie";
import RocketIcon from "@mui/icons-material/Rocket";
import CommuteIcon from "@mui/icons-material/Commute";
import { useEffect, useState } from "react";
import API_URL from "../shared/constants";

interface MyPerson {
  name: string;
  filmTitles: { title: string }[];
  starshipNames: { name: string }[];
  vehicleNames: { name: string }[];
}

function Person() {
  const [person, setPerson] = useState<MyPerson>();

  useEffect(() => {
    populatePersonData();
  }, []);

  const contents =
    person === undefined ? (
      <CircularProgress />
    ) : (
      <div style={{ display: "flex", flexDirection: "column" }}>
        <h1>{person.name}</h1>
        <div style={{ display: "flex", justifyContent: "space-evenly" }}>
          <div
            style={{
              display: "flex",
              flexDirection: "column",
              width: "300px",
              gap: "0px 16px",
            }}
          >
            <div
              style={{
                display: "flex",
                alignItems: "center",
                flexWrap: "wrap",
                gap: "8px",
              }}
            >
              <MovieIcon />
              <h2>Films</h2>
            </div>
            <List>
              {person.filmTitles.map((item) => (
                <ListItem disablePadding>
                  <ListItemText sx={{ pl: 4 }} primary={`• ${item.title}`} />
                </ListItem>
              ))}
            </List>
          </div>
          <div
            style={{ display: "flex", flexDirection: "column", width: "300px" }}
          >
            <div
              style={{
                display: "flex",
                alignItems: "center",
                flexWrap: "wrap",
                gap: "8px",
              }}
            >
              <RocketIcon />
              <h2>Starships</h2>
            </div>
            <List>
              {person.starshipNames.map((item) => (
                <ListItem disablePadding>
                  <ListItemText sx={{ pl: 4 }} primary={`• ${item.name}`} />
                </ListItem>
              ))}
            </List>
          </div>
          <div
            style={{ display: "flex", flexDirection: "column", width: "300px" }}
          >
            <div
              style={{
                display: "flex",
                alignItems: "center",
                flexWrap: "wrap",
                gap: "8px",
              }}
            >
              <CommuteIcon />
              <h2>Vehicles</h2>
            </div>
            <List>
              {person.vehicleNames.map((item) => (
                <ListItem disablePadding>
                  <ListItemText sx={{ pl: 4 }} primary={`• ${item.name}`} />
                </ListItem>
              ))}
            </List>
          </div>
        </div>
      </div>
    );

  return <>{contents}</>;

  async function populatePersonData() {
    fetch(API_URL)
      .then((response) => {
        return response.json();
      })
      .then((responseJson) => {
        setPerson(responseJson);
      });
  }
}

export default Person;
