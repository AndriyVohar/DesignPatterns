class UserLoader {
  constructor(file) {
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

        const id = xmlDoc.querySelector("id").textContent;
        const name = xmlDoc.querySelector("name").textContent;
        const avatar = xmlDoc.querySelector("avatar").textContent;

        this.data = {
          id: id,
          name: name,
          avatar: avatar,
        };
      });
  }

  getUserData() {
    return this.data;
  }
}
