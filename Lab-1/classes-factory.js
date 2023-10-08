// Варіант 4. Розробити клас підсистеми для завантаження даних про онлайн зустріч (дата, опис, URL,
// список учасників) та списку всіх користувачів системи (ID, Ім'я, аватар) з файлів в форматі JSON та XML.
// Визначення типу файлу визначається при запуску системи. Передбачити, що дані про кожну зустріч та кожного
// користувача зберігаються в окремих файлах. Файл зустрічі містить імена файлів - учасників цієї зустрічі.

class MeetingLoader {
  constructor() {}

  load(data) {
    this.data = {
      date: data.date,
      description: data.description,
      url: data.url,
      participants: data.participants,
    };
  }

  getData() {
    return this.data;
  }
}

class UserLoader {
  constructor() {}

  load(data) {
    this.data = {
      id: data.id,
      name: data.name,
      avatar: data.avatar,
    };
  }

  getData() {
    return this.data;
  }
}

class DataLoaderFactory {
  createLoader(file) {
    let fileType = file.split(".").pop();
    if (fileType === "json") {
      return new JsonLoader();
    } else if (fileType === "xml") {
      return new XmlLoader();
    }
  }
}
class JsonLoader {
  async loadFromFile(file) {
    try {
      let response = await fetch(file);
      let jsonData = await response.json();
      return jsonData;
    } catch (error) {
      console.error("Error loading JSON data:", error);
      return null;
    }
  }
}

class XmlLoader {
  async loadFromFile(file) {
    try {
      let response = await fetch(file);
      let xml = await response.text();
      let parser = new DOMParser();
      let xmlDoc = parser.parseFromString(xml, "text/xml");

      if (xmlDoc.querySelector("date")) {
        let date = xmlDoc.querySelector("date").textContent;
        let description = xmlDoc.querySelector("description").textContent;
        let url = xmlDoc.querySelector("url").textContent;

        let participants = [];
        let participantElements = xmlDoc.querySelectorAll("participant");
        participantElements.forEach((participantElement) => {
          participants.push(participantElement.textContent);
        });

        return {
          date: date,
          description: description,
          url: url,
          participants: participants,
        };
      } else if (xmlDoc.querySelector("id")) {
        let id = xmlDoc.querySelector("id").textContent;
        let name = xmlDoc.querySelector("name").textContent;
        let avatar = xmlDoc.querySelector("avatar").textContent;

        return {
          id: id,
          name: name,
          avatar: avatar,
        };
      }
    } catch (error) {
      console.error("Error loading XML data:", error);
      return null;
    }
  }
}
