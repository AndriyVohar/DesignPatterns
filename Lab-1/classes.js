class Loader {
  loadData(file) {
    this.data;
    const extension = file.split(".").pop();

    if (extension === "json") {
      this.loadJson(file);
    } else if (extension === "xml") {
      this.loadXml(file);
    }
  }
  loadJson(file) {
    fetch(file)
      .then((response) => response.json())
      .then((data) => {
        this.data = data;
      });
  }
  loadXml(file) {
    fetch(file)
      .then((response) => response.text())
      .then((xml) => {
        const parser = new DOMParser();
        const xmlDoc = parser.parseFromString(xml, "text/xml");

        if (xmlDoc.querySelector("date")) {
          const date = xmlDoc.querySelector("date").textContent;
          const description = xmlDoc.querySelector("description").textContent;
          const url = xmlDoc.querySelector("url").textContent;

          const participants = [];
          const participantElements = xmlDoc.querySelectorAll("participant");
          participantElements.forEach((participantElement) => {
            participants.push(participantElement.textContent);
          });

          this.data = {
            date: date,
            description: description,
            url: url,
            participants: participants,
          };
        } else if (xmlDoc.querySelector("id")) {
          const id = xmlDoc.querySelector("id").textContent;
          const name = xmlDoc.querySelector("name").textContent;
          const avatar = xmlDoc.querySelector("avatar").textContent;

          this.data = {
            id: id,
            name: name,
            avatar: avatar,
          };
        }
      });
  }
}
